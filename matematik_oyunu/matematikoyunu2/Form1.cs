namespace matematikoyunu2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // --- Mevcut Değişkenler (Güncellenmiş) ---
        double dogruCevap = 0; // Bölme işleminde virgüllü olacağından
                               // NOT: txtDogruCevap ve txtYanlisCevap sadece mevcut 5'li bloktaki sonucu gösterecek.
                               // Seviye geçişi için toplam doğruyu ayrı tutacağız.
        int dogruCevapSayisi = 0; // Mevcut bloktaki/seviyedeki doğru sayısı
        int yanlisCevapSayisi = 0; // Mevcut bloktaki/seviyedeki yanlış sayısı
        int zaman = 0; // Kalan zaman (saniye cinsinden)

        Random random = new Random();

        // --- Yeni Gereksinimler İçin Eklenen Değişkenler ---

        // Seviye ve Soru Takibi
        int mevcutSeviye = 1; // Başlangıç seviyesi
        const int toplamSeviye = 5; // Toplam seviye sayısı
        const int soruBlokBoyutu = 5; // Her bloktaki soru sayısı
        const int blokSayisi = 4; // Her seviyedeki blok sayısı (Toplam 20 soru)
        int mevcutBlok = 1; // Şu anki soru bloğu
        int mevcutBlokIciSoruSayisi = 1; // Blok içindeki kaçıncı soru (1'den 5'e)
        int seviyeDogruSayisi = 0; // Seviye atlamak için toplam doğru sayısı (20 soruda)

        // Pas Geçme Mekanizması
        // Pas geçilen soruları (Sayı1, Sayı2, İşlem Türü) tutar
        List<Tuple<int, int, string, int, int>> pasGecilenSorular = new List<Tuple<int, int, string, int, int>>();
        int pasHakki = 2; // Bir soruyu pas geçme hakkı
        bool pasSoruCozuluyor = false;
        // Puanlama ve Skor
        int mevcutPuan = 0; // Oyuncunun toplam puanı
        string skorDosyaAdi = "skorlar.txt";
        string ilerlemeDosyaAdi = "ilerleme.txt";

        // Süre Ayarları (saniye cinsinden)
        // Seviye atladıkça süre artıyor ve seviyeden seviyeye değişiyor.
        int[] seviyeSuresiSaniye = { 15, 20, 30, 35, 40 };

        // Hile Mekanizması
        int kilitAcikSeviye = 1; // Komut satırı argümanı ile açılan seviye

        string[] islemTipleri = { "Toplama(+)", "Çıkarma(-)", "Çarpma(*)", "Bölme(/)" };

        private void Form1_Load(object sender, EventArgs e)
        {
            // Komut satırı argümanlarını kontrol et (Hile)
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length == 3 && args[1].ToLower() == "open")
            {
                if (int.TryParse(args[2], out int hileSeviye) && hileSeviye >= 2 && hileSeviye <= toplamSeviye)
                {
                    kilitAcikSeviye = hileSeviye;
                    MessageBox.Show($"{kilitAcikSeviye}. seviyenin kilidi hile ile açıldı.", "Hile Aktif");
                }
                else if (args[2].ToLower() == "all")
                {
                    kilitAcikSeviye = toplamSeviye + 1; // Tüm seviyeler açık
                    MessageBox.Show("Tüm seviyeler hile ile açıldı.", "Hile Aktif");
                }
            }

            // Kalınan seviyeden devam et
            SeviyeYukle();

            // Form üzerindeki initial değerleri ayarla
            txtSeviye.Text = mevcutSeviye.ToString();
            txtPuan.Text = mevcutPuan.ToString();
            txtSoruTakip.Text = mevcutBlokIciSoruSayisi.ToString();
            lblBlok.Text = $"Blok: {mevcutBlok}/{blokSayisi}";
            // Seviye süresi dizinin sınırları içinde kalmasını sağla
            int seviyeIndex = Math.Min(mevcutSeviye, seviyeSuresiSaniye.Length) - 1;
            txtSure.Text = seviyeSuresiSaniye[seviyeIndex].ToString();

            // Kullanıcıların cmb seçimlerini yapması beklenir.
            btnCevapla.Enabled = false;
            btnPasGec.Enabled = false;
        }



        private void btnOyunuBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                // UI ve sayaçları sıfırla/başlat
                btnCevapla.Enabled = true;
                btnPasGec.Enabled = true;
                txtCevap.Enabled = true;

                // Oyun başladığında sayaçları sıfırla (eğer ilk başlangıç değilse)
                dogruCevapSayisi = 0; // Mevcut blok için
                yanlisCevapSayisi = 0; // Mevcut blok için
                seviyeDogruSayisi = 0; // Yeni seviye için sıfırlanır
                mevcutBlok = 1;
                mevcutBlokIciSoruSayisi = 1;
                pasHakki = 2; // Her seviye başlangıcında pas hakkı yenilenir.
                pasGecilenSorular.Clear();

                // UI Güncelleme
                txtDogruCevap.Text = "0";
                txtYanlisCevap.Text = "0";
                txtSoruTakip.Text = "1";
                lblBlok.Text = $"Blok: 1/{blokSayisi}";
                txtSeviye.Text = mevcutSeviye.ToString(); // Yüklenen seviyeyi göster

                // Süreyi seviyeye göre ayarla ve başlat
                int seviyeIndex = Math.Min(mevcutSeviye, seviyeSuresiSaniye.Length) - 1;
                zaman = seviyeSuresiSaniye[seviyeIndex];
                txtSure.Text = zaman.ToString();

                SorulariOlustur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oyun Başlatılırken hata alındı. " + ex.Message);
            }
        }

       
        void SorulariOlustur(bool pasGecilenSoruIcin = false)
        {
            string islemTuru = ""; // "Toplama(+)" gibi tam metin
            string islemSembolu = ""; // "+" gibi sembol

            try
            {
                txtCevap.Text = "";
                txtCevap.Focus();

                // Pas geçilen soru çözülüyorsa, listeden çek
                if (pasGecilenSoruIcin && pasGecilenSorular.Count > 0)
                {
                    var soru = pasGecilenSorular[0];
                    timer1.Start();
                    lblSayi1.Text = soru.Item1.ToString();
                    lblSayi2.Text = soru.Item2.ToString();
                    lblIslemTuru.Text = soru.Item3;
                    dogruCevap = Hesapla(soru.Item1, soru.Item2, soru.Item3);
                    return;
                }
                // Eğer pas geçilen soru çözüyorsak ve liste boşsa, yeni soruya geç
                if (pasGecilenSoruIcin && pasGecilenSorular.Count == 0)
                {
                    pasSoruCozuluyor = false;
                    GelecekSoruKontrolu();
                    return;
                }

                // --- Yeni Soru Oluşturma ---
                // Rastgele tam metni seç
                int rastgeleIndex = random.Next(islemTipleri.Length);
                islemTuru = islemTipleri[rastgeleIndex];

                // Sembolü metinden çıkar
                islemSembolu = islemTuru.Substring(islemTuru.IndexOf('(') + 1).TrimEnd(')');
                timer1.Start();

                int minSayi = 0;
                int maxSayi = 0;

                // Seviye atlandıkça basamak sayısı artmalı
                if (mevcutSeviye == 1) { minSayi = 1; maxSayi = 10; } // 1-10
                else if (mevcutSeviye == 2) { minSayi = 10; maxSayi = 50; } // 10-50
                else if (mevcutSeviye == 3) { minSayi = 10; maxSayi = 99; } // 10-99 (2 basamaklılar)
                else if (mevcutSeviye == 4) { minSayi = 50; maxSayi = 200; } // 50-200
                else if (mevcutSeviye == 5) { minSayi = 100; maxSayi = 999; } // 100-999 (3 basamaklılar)

                // Zorluk seviyesi combox'ından da aralık belirlenebilir, ancak gereksinime göre
                // "Seviye atlandıkça işlemlerin basamak sayısı artmalı" kuralını uyguluyoruz.

                int sayi1 = random.Next(minSayi, maxSayi + 1);
                int sayi2 = random.Next(minSayi, maxSayi + 1);
                
               
               
                // Bölme için tam sayı çıkması kontrolü (opsiyonel ama tavsiye edilir)
                if (islemTuru == "Bölme(/)")
                {
                    if (sayi2 == 0) sayi2 = 1;
                    int kat = random.Next(1, 10);
                    sayi1 = sayi2 * kat;
                }

                // Çıkarma için sonuç negatif çıkmaması kontrolü (opsiyonel)
                if (islemTuru == "Çıkarma(-)")
                {
                    if (sayi2 > sayi1)
                    {
                        // Yer değiştir
                        int temp = sayi1;
                        sayi1 = sayi2;
                        sayi2 = temp;
                    }
                }

                lblSayi1.Text = sayi1.ToString();
                lblSayi2.Text = sayi2.ToString();

                // Label'a sadece sembolü atayın
                lblIslemTuru.Text = islemTuru;

                dogruCevap = Hesapla(sayi1, sayi2, islemTuru);
            }
            catch (Exception)
            {
                // Genellikle cmb seçimi yapılmadığında buraya düşer.
                MessageBox.Show("Soru oluşturulurken bir hata oluştu.", "Hata");
            }
        }

        // Hesaplama Yardımcı Metodu
        private double Hesapla(int sayi1, int sayi2, string islemTuru)
        {
            // islemTuru TAM METİN ("Toplama(+)") içermelidir.
            if (islemTuru.Contains("Toplama")) return (double)sayi1 + sayi2;
            if (islemTuru.Contains("Çıkarma")) return (double)sayi1 - sayi2;
            if (islemTuru.Contains("Çarpma")) return (double)sayi1 * sayi2;
            if (islemTuru.Contains("Bölme"))
            {
                if (sayi2 == 0) return 0;
                return (double)sayi1 / sayi2;
            }
            return 0;
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            if (zaman > 0)
            {
                zaman--;
                txtSure.Text = zaman.ToString();
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Süre Bitti..Oyun Bitti..");
                txtCevap.Enabled = false;
                btnPasGec.Enabled = false;

                // Süre bitince Seviye geçiş kontrolünü tetikle (Başarısızlık durumuna düşecek)
                SeviyeGecisKontrolu();
            }
        }
        // Puanlama Yardımcı Metodu (Doğru cevaba göre puan hesaplar)
        private void PuanEkle()
        {
            // Basit Puanlama Mantığı: Seviye * 10 Puan
            int kazanilanPuan = mevcutSeviye * 10;

            if (pasSoruCozuluyor)
            {
                // Pas geçilen soruları çözmek daha az puan kazandırsın
                kazanilanPuan = (int)(kazanilanPuan * 0.5);
            }

            mevcutPuan += kazanilanPuan;
            txtPuan.Text = mevcutPuan.ToString();
        }

        // Pas Geçme Butonu
        private void btnPasGec_Click(object sender, EventArgs e)
        {
            if (pasHakki > 0)
            {
                string pasIslemTuru = lblIslemTuru.Text; // Burası şu an sadece Sembol ("+")
                // Pas geçilen soruyu listeye kaydet (pas hakki bittiğinde geri döneceğiz)
                // Kaydedilen veriler: Sayı1, Sayı2, İşlem Türü, Blok No, Soru No
                pasGecilenSorular.Add(new Tuple<int, int, string, int, int>(
                    int.Parse(lblSayi1.Text),
                    int.Parse(lblSayi2.Text),
                   pasIslemTuru,
                    mevcutBlok,
                    mevcutBlokIciSoruSayisi
                ));

                pasHakki--;
                // NOT: Pas Hakkı Label'ı (`lblPasHakki`) eksikti. Tasarımda bu `Name`'i kullanarak güncelleyin.
                // Şimdilik pas hakkı bittiğinde butonu devre dışı bırakalım
                if (pasHakki == 0)
                {
                    btnPasGec.Enabled = false;
                }

                MessageBox.Show($"Soruyu pas geçtiniz. Kalan Pas Hakkınız: {pasHakki}", "Pas Geçildi");
                // Bir sonraki soruya geç
                GelecekSoruKontrolu();
            }
            else
            {
                MessageBox.Show("Pas geçme hakkınız kalmadı!", "Uyarı");
            }
        }

        // Cevaplama Butonu
        // btnOnayla_Click metodu yerine btnCevapla_Click olarak düzenliyoruz
        private void btnCevapla_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (!double.TryParse(txtCevap.Text.Replace('.', ','), out double kullaniciCevabi))
            {
                MessageBox.Show("Lütfen geçerli bir sayı giriniz.", "Hata");
                timer1.Start();
                return;
            }

            // Yuvarlama kontrolü (bölme işleminde ondalık gelirse)
            bool cevapDogru = Math.Round(kullaniciCevabi, 2) == Math.Round(dogruCevap, 2);

            if (cevapDogru)
            {
                MessageBox.Show("Doğru Cevap!", "Tebrikler");
                PuanEkle();

                // Eğer pas geçilen soruyu çözdüysek, listeden sil
                if (pasSoruCozuluyor)
                {
                    pasGecilenSorular.RemoveAt(0); // İlk soruyu listeden kaldır
                    // Eğer pas geçilen sorular bittiyse, normal akışa dön
                    if (pasGecilenSorular.Count == 0)
                    {
                        pasSoruCozuluyor = false;
                    }
                }
                else
                {
                    // Normal akışta doğru sayısı
                    dogruCevapSayisi++;
                    seviyeDogruSayisi++;
                }
            }
            else
            {
                MessageBox.Show($"Yanlış Cevap. Doğrusu: {Math.Round(dogruCevap, 2)} idi.", "Hata");

                // Sadece normal akışta yanlış sayısını artır
                if (!pasSoruCozuluyor)
                {
                    yanlisCevapSayisi++;
                }
            }

            // UI Güncelleme (Sadece normal bloktaki doğru/yanlış sayısını gösterir)
            txtDogruCevap.Text = dogruCevapSayisi.ToString();
            txtYanlisCevap.Text = yanlisCevapSayisi.ToString();

            // Bir sonraki soruya veya akış kontrolüne geç
            GelecekSoruKontrolu();
        }
        // --- Oyun Akış Metotları ---

        private void GelecekSoruKontrolu()
        {
            // Pas geçilen soruyu çözüyorsak, bir sonraki pas sorusuna geç
            if (pasSoruCozuluyor)
            {
                // Pas soruları bitmişse, normal akışa dön
                if (pasGecilenSorular.Count == 0)
                {
                    pasSoruCozuluyor = false;
                    // Pas soruları çözüldükten sonra normal akışa devam et
                    // Aşağıdaki kod normal akışı yönetecektir.
                }
                else
                {
                    // Bir sonraki pas sorusuna geç
                    SorulariOlustur(true);
                    return;
                }
            }

            // Blok içindeki sayacı artır
            mevcutBlokIciSoruSayisi++;

            // UI Güncelleme
            txtSoruTakip.Text = mevcutBlokIciSoruSayisi.ToString();

            // 5 soru bitti mi?
            if (mevcutBlokIciSoruSayisi > soruBlokBoyutu)
            {
                // Blok Bitti
                mevcutBlok++;

                // UI Sıfırlama
                mevcutBlokIciSoruSayisi = 1;
                txtSoruTakip.Text = mevcutBlokIciSoruSayisi.ToString();

                // Blok sayaçlarını sıfırla (blok skorları)
                dogruCevapSayisi = 0;
                yanlisCevapSayisi = 0;
                txtDogruCevap.Text = "0";
                txtYanlisCevap.Text = "0";

                // UI Sıfırlama(Blok 1.soruya geri döner)
                mevcutBlokIciSoruSayisi = 1;
                txtSoruTakip.Text = mevcutBlokIciSoruSayisi.ToString();
                // Seviye Bitti mi?
                if (mevcutBlok > blokSayisi)
                {
                    // Seviye sonuna ulaştık (4. blok bitti)
                    SeviyeGecisKontrolu();
                    return;
                }

                // UI Güncelleme
                lblBlok.Text = $"Blok: {mevcutBlok}/{blokSayisi}";
            }

            // Pas geçilen sorular var mı ve hakkımız bitti mi?
            if (pasGecilenSorular.Count > 0 && pasHakki == 0)
            {
                pasSoruCozuluyor = true;
                MessageBox.Show("Pas haklarınız bitti. Şimdi pas geçilen soruları çözmelisiniz.", "Pas Soruları");
                SorulariOlustur(true); // Pas geçilen ilk soruyu getir
                return;
            }

            // Yeni normal soru oluştur
            SorulariOlustur();
        }

        private void SeviyeGecisKontrolu()
        {
            timer1.Stop();

            // Gereksinim: 11 doğru
            const int basariKurali = 11;
            string yildizDurumu = "";

            // Yıldız Derecelendirmesi
            if (seviyeDogruSayisi >= 19) { yildizDurumu = "3 Yıldız (19-20 Doğru) ⭐⭐⭐"; }
            else if (seviyeDogruSayisi >= 16) { yildizDurumu = "2 Yıldız (16-18 Doğru) ⭐⭐"; }
            else if (seviyeDogruSayisi >= basariKurali) { yildizDurumu = "1 Yıldız (11-15 Doğru) ⭐"; }

            if (seviyeDogruSayisi >= basariKurali)
            {
                // Başarılı
                mevcutSeviye++;
                SeviyeKaydet();

                if (mevcutSeviye > toplamSeviye)
                {
                    // Oyun Tamamlandı
                    MessageBox.Show($"Tüm seviyeleri başarıyla tamamladınız!\nToplam Puanınız: {mevcutPuan}", "Oyun Sonu");
                    // SkorKaydet(); // Metot yoksa yorum satırı
                    btnOyunuBaslat.Enabled = false;
                    btnCevapla.Enabled = false;
                    btnPasGec.Enabled = false;
                    return;
                }

                MessageBox.Show($"Tebrikler! {mevcutSeviye - 1}. Seviyeyi başarıyla geçtiniz.\nBaşarı Dereceniz: {yildizDurumu}\nYeni seviye: {mevcutSeviye}", "Seviye Atlandı");

                // Yeni seviye ayarları için reset
                txtSeviye.Text = mevcutSeviye.ToString();
                int seviyeIndex = Math.Min(mevcutSeviye, seviyeSuresiSaniye.Length) - 1;
                zaman = seviyeSuresiSaniye[seviyeIndex];
                txtSure.Text = zaman.ToString();

                mevcutBlok = 1;
                seviyeDogruSayisi = 0;
                pasHakki = 2;
                pasGecilenSorular.Clear();

                btnCevapla.Enabled = false;
                btnPasGec.Enabled = false;
                MessageBox.Show("Yeni seviyeye başlamak için 'Oyunu Başlat' butonuna tekrar basınız.", "Devam Et");
            }
            else
            {
                // Başarısız
                MessageBox.Show($"Maalesef {mevcutSeviye}. seviyeyi geçemediniz. Gerekli doğru sayısı: {basariKurali}.\nSizin doğrunuz: {seviyeDogruSayisi}.\nTekrar deneyin.", "Seviye Başarısız");

                // Tekrar başlatma opsiyonu
                btnCevapla.Enabled = false;
                btnPasGec.Enabled = false;
                btnOyunuBaslat.Enabled = true;

                // Seviye skorlarını sıfırla (tekrar denemek için)
                mevcutBlok = 1;
                seviyeDogruSayisi = 0;
                pasHakki = 2;
                pasGecilenSorular.Clear();
            }
        }

        // --- Dosya İşlemleri Metotları ---

        private void SeviyeYukle()
        {
            // İlerleme dosyasını okuyarak kalınan seviyeyi yükler
            if (File.Exists(ilerlemeDosyaAdi))
            {
                string dosyaIcerigi = File.ReadAllText(ilerlemeDosyaAdi);
                if (int.TryParse(dosyaIcerigi, out int yuklenenSeviye) && yuklenenSeviye > 1)
                {
                    // Hile ile açılan seviye, kayıttaki seviyeden büyükse hileyi kullan
                    mevcutSeviye = Math.Max(yuklenenSeviye, kilitAcikSeviye);
                }
                else
                {
                    mevcutSeviye = kilitAcikSeviye;
                }
            }
            else
            {
                mevcutSeviye = kilitAcikSeviye;
            }
        }

        private void SeviyeKaydet()
        {
            // Mevcut seviyeyi dosyaya kaydeder
            try
            {
                File.WriteAllText(ilerlemeDosyaAdi, mevcutSeviye.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("İlerleme kaydedilirken hata oluştu: " + ex.Message);
            }
        }

    }
}
