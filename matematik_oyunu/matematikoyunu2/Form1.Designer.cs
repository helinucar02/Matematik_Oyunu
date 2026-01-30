namespace matematikoyunu2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            lblBlok = new Label();
            label14 = new Label();
            txtSoruTakip = new TextBox();
            txtSeviye = new TextBox();
            label13 = new Label();
            btnOyunuBaslat = new Button();
            lblSüre = new Label();
            lblSoruSayisi = new Label();
            txtSure = new TextBox();
            txtSoruSayisi = new TextBox();
            labelBlok = new Label();
            lblİslemTuru = new Label();
            panel2 = new Panel();
            btnCevapla = new Button();
            txtCevap = new TextBox();
            btnPasGec = new Button();
            lblSayi2 = new Label();
            lblSayi1 = new Label();
            panel3 = new Panel();
            txtPuan = new TextBox();
            groupBox3 = new GroupBox();
            txtYanlisCevap = new TextBox();
            label8 = new Label();
            txtDogruCevap = new TextBox();
            label7 = new Label();
            label6 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblBlok);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtSoruTakip);
            panel1.Controls.Add(txtSeviye);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(btnOyunuBaslat);
            panel1.Controls.Add(lblSüre);
            panel1.Controls.Add(lblSoruSayisi);
            panel1.Controls.Add(txtSure);
            panel1.Controls.Add(txtSoruSayisi);
            panel1.Controls.Add(labelBlok);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(272, 450);
            panel1.TabIndex = 0;
            // 
            // lblBlok
            // 
            lblBlok.BackColor = SystemColors.ButtonHighlight;
            lblBlok.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblBlok.Location = new Point(115, 28);
            lblBlok.Name = "lblBlok";
            lblBlok.Size = new Size(150, 23);
            lblBlok.TabIndex = 22;
            // 
            // label14
            // 
            label14.BackColor = SystemColors.Control;
            label14.CausesValidation = false;
            label14.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label14.Location = new Point(7, 113);
            label14.Name = "label14";
            label14.Size = new Size(101, 24);
            label14.TabIndex = 21;
            label14.Text = "Soru :";
            label14.TextAlign = ContentAlignment.TopRight;
            // 
            // txtSoruTakip
            // 
            txtSoruTakip.Location = new Point(114, 110);
            txtSoruTakip.Name = "txtSoruTakip";
            txtSoruTakip.Size = new Size(151, 27);
            txtSoruTakip.TabIndex = 20;
            txtSoruTakip.Text = "1";
            // 
            // txtSeviye
            // 
            txtSeviye.Location = new Point(152, 160);
            txtSeviye.Name = "txtSeviye";
            txtSeviye.Size = new Size(113, 27);
            txtSeviye.TabIndex = 19;
            // 
            // label13
            // 
            label13.BackColor = SystemColors.Control;
            label13.CausesValidation = false;
            label13.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label13.Location = new Point(2, 160);
            label13.Name = "label13";
            label13.Size = new Size(144, 24);
            label13.TabIndex = 11;
            label13.Text = "Mevcut Seviye :";
            // 
            // btnOyunuBaslat
            // 
            btnOyunuBaslat.BackColor = Color.MistyRose;
            btnOyunuBaslat.Location = new Point(11, 342);
            btnOyunuBaslat.Name = "btnOyunuBaslat";
            btnOyunuBaslat.Size = new Size(254, 49);
            btnOyunuBaslat.TabIndex = 10;
            btnOyunuBaslat.Text = "Oyunu Başlat";
            btnOyunuBaslat.UseVisualStyleBackColor = false;
            btnOyunuBaslat.Click += btnOyunuBaslat_Click;
            // 
            // lblSüre
            // 
            lblSüre.AutoSize = true;
            lblSüre.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSüre.Location = new Point(55, 207);
            lblSüre.Name = "lblSüre";
            lblSüre.Size = new Size(53, 23);
            lblSüre.TabIndex = 9;
            lblSüre.Text = "Süre :";
            // 
            // lblSoruSayisi
            // 
            lblSoruSayisi.AutoSize = true;
            lblSoruSayisi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSoruSayisi.Location = new Point(7, 65);
            lblSoruSayisi.Name = "lblSoruSayisi";
            lblSoruSayisi.Size = new Size(101, 23);
            lblSoruSayisi.TabIndex = 8;
            lblSoruSayisi.Text = "Soru Sayısı :";
            // 
            // txtSure
            // 
            txtSure.Location = new Point(113, 207);
            txtSure.Name = "txtSure";
            txtSure.Size = new Size(151, 27);
            txtSure.TabIndex = 7;
            txtSure.Text = "15";
            // 
            // txtSoruSayisi
            // 
            txtSoruSayisi.Location = new Point(114, 65);
            txtSoruSayisi.Name = "txtSoruSayisi";
            txtSoruSayisi.Size = new Size(151, 27);
            txtSoruSayisi.TabIndex = 6;
            txtSoruSayisi.Text = "5";
            // 
            // labelBlok
            // 
            labelBlok.AutoSize = true;
            labelBlok.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            labelBlok.Location = new Point(41, 28);
            labelBlok.Name = "labelBlok";
            labelBlok.Size = new Size(52, 23);
            labelBlok.TabIndex = 2;
            labelBlok.Text = "Blok :";
            // 
            // lblİslemTuru
            // 
            lblİslemTuru.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblİslemTuru.BackColor = Color.FromArgb(255, 224, 192);
            lblİslemTuru.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblİslemTuru.Location = new Point(98, 58);
            lblİslemTuru.Name = "lblİslemTuru";
            lblİslemTuru.Size = new Size(88, 29);
            lblİslemTuru.TabIndex = 3;
            lblİslemTuru.Text = "islem";
            lblİslemTuru.TextAlign = ContentAlignment.TopCenter;
            lblİslemTuru.UseMnemonic = false;
            lblİslemTuru.UseWaitCursor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCevapla);
            panel2.Controls.Add(lblİslemTuru);
            panel2.Controls.Add(txtCevap);
            panel2.Controls.Add(btnPasGec);
            panel2.Controls.Add(lblSayi2);
            panel2.Controls.Add(lblSayi1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(272, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(528, 211);
            panel2.TabIndex = 1;
            // 
            // btnCevapla
            // 
            btnCevapla.BackColor = Color.MistyRose;
            btnCevapla.Location = new Point(30, 139);
            btnCevapla.Name = "btnCevapla";
            btnCevapla.Size = new Size(192, 35);
            btnCevapla.TabIndex = 13;
            btnCevapla.Text = "Cevapla";
            btnCevapla.UseVisualStyleBackColor = false;
            btnCevapla.Click += btnCevapla_Click;
            // 
            // txtCevap
            // 
            txtCevap.Cursor = Cursors.SizeAll;
            txtCevap.Location = new Point(286, 63);
            txtCevap.Name = "txtCevap";
            txtCevap.Size = new Size(95, 27);
            txtCevap.TabIndex = 14;
            // 
            // btnPasGec
            // 
            btnPasGec.BackColor = Color.MistyRose;
            btnPasGec.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnPasGec.Location = new Point(402, 58);
            btnPasGec.Name = "btnPasGec";
            btnPasGec.Size = new Size(105, 34);
            btnPasGec.TabIndex = 11;
            btnPasGec.Text = "Pas Geç";
            btnPasGec.UseVisualStyleBackColor = false;
            btnPasGec.Click += btnPasGec_Click;
            // 
            // lblSayi2
            // 
            lblSayi2.CausesValidation = false;
            lblSayi2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSayi2.Location = new Point(174, 62);
            lblSayi2.Name = "lblSayi2";
            lblSayi2.Size = new Size(95, 30);
            lblSayi2.TabIndex = 4;
            lblSayi2.Text = "SAYI2";
            lblSayi2.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSayi1
            // 
            lblSayi1.CausesValidation = false;
            lblSayi1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSayi1.Location = new Point(6, 58);
            lblSayi1.Name = "lblSayi1";
            lblSayi1.Size = new Size(95, 30);
            lblSayi1.TabIndex = 4;
            lblSayi1.Text = "SAYI1";
            lblSayi1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtPuan);
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(label6);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(272, 211);
            panel3.Name = "panel3";
            panel3.Size = new Size(528, 239);
            panel3.TabIndex = 2;
            // 
            // txtPuan
            // 
            txtPuan.Location = new Point(141, 25);
            txtPuan.Name = "txtPuan";
            txtPuan.Size = new Size(81, 27);
            txtPuan.TabIndex = 13;
            txtPuan.Text = "0";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.Control;
            groupBox3.Controls.Add(txtYanlisCevap);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(txtDogruCevap);
            groupBox3.Controls.Add(label7);
            groupBox3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            groupBox3.Location = new Point(236, 65);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(289, 125);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sonuçlar";
            // 
            // txtYanlisCevap
            // 
            txtYanlisCevap.Enabled = false;
            txtYanlisCevap.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtYanlisCevap.Location = new Point(177, 76);
            txtYanlisCevap.Name = "txtYanlisCevap";
            txtYanlisCevap.Size = new Size(106, 34);
            txtYanlisCevap.TabIndex = 11;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(255, 128, 128);
            label8.CausesValidation = false;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label8.Location = new Point(0, 76);
            label8.Name = "label8";
            label8.Size = new Size(171, 34);
            label8.TabIndex = 10;
            label8.Text = "Yanlış Cevap Sayısı : ";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDogruCevap
            // 
            txtDogruCevap.Enabled = false;
            txtDogruCevap.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtDogruCevap.Location = new Point(177, 29);
            txtDogruCevap.Name = "txtDogruCevap";
            txtDogruCevap.Size = new Size(106, 34);
            txtDogruCevap.TabIndex = 9;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(192, 255, 192);
            label7.CausesValidation = false;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label7.Location = new Point(0, 32);
            label7.Name = "label7";
            label7.Size = new Size(171, 34);
            label7.TabIndex = 4;
            label7.Text = "Doğru Cevap Sayısı :";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.BackColor = Color.Bisque;
            label6.CausesValidation = false;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.Location = new Point(6, 28);
            label6.Name = "label6";
            label6.Size = new Size(123, 24);
            label6.TabIndex = 5;
            label6.Text = "Puan :";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Matematik Oyunu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label lblSüre;
        private Label lblSoruSayisi;
        private TextBox txtSure;
        private TextBox txtSoruSayisi;
        private ComboBox cmbİslemTuru;
        private Label lblIslemTuru;
        private ComboBox cmbBlok;
        private Label labelBlok;
        private Button btnOyunuBaslat;
        private Label lblİslemTuru;
        private Label lblSayi2;
        private Label lblSayi1;
        private GroupBox groupBox3;
        private Label label7;
        private Button btnPasGec;
        private TextBox txtYanlisCevap;
        private Label label8;
        private TextBox txtDogruCevap;
        private System.Windows.Forms.Timer timer1;
        private TextBox txtCevap;
        private Button btnCevapla;
        private TextBox txtSeviye;
        private Label label13;
        private TextBox txtPuan;
        private Label label14;
        private TextBox txtSoruTakip;
        private Label label6;
        private Label lblBlok;
    }
}
