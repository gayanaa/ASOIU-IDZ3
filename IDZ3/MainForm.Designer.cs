namespace IDZ3
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnStudios = new Button();
            btnFilms = new Button();
            btnReports = new Button();
            pictureBoxLogo = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnStudios
            // 
            btnStudios.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStudios.Location = new Point(204, 106);
            btnStudios.Name = "btnStudios";
            btnStudios.Size = new Size(200, 50);
            btnStudios.TabIndex = 0;
            btnStudios.Text = "Киностудии";
            btnStudios.UseVisualStyleBackColor = true;
            btnStudios.Click += btnStudios_Click;
            // 
            // btnFilms
            // 
            btnFilms.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFilms.Location = new Point(204, 176);
            btnFilms.Name = "btnFilms";
            btnFilms.Size = new Size(200, 50);
            btnFilms.TabIndex = 1;
            btnFilms.Text = "Фильмы";
            btnFilms.UseVisualStyleBackColor = true;
            btnFilms.Click += btnFilms_Click;
            // 
            // btnReports
            // 
            btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReports.Location = new Point(204, 244);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(200, 50);
            btnReports.TabIndex = 2;
            btnReports.Text = "Отчёты";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = Properties.Resources.IMG_6831;
            pictureBoxLogo.Location = new Point(366, 305);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(234, 240);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 3;
            pictureBoxLogo.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.IMG_6833;
            pictureBox2.Location = new Point(21, 333);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 159);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(21, 513);
            label1.Name = "label1";
            label1.Size = new Size(339, 32);
            label1.TabIndex = 5;
            label1.Text = "Ахметзянова Гаяна | ИУ5-23Б";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 570);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBoxLogo);
            Controls.Add(btnReports);
            Controls.Add(btnFilms);
            Controls.Add(btnStudios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление киностудиями и фильмами";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnStudios;
        private Button btnFilms;
        private Button btnReports;
        private PictureBox pictureBoxLogo;
        private PictureBox pictureBox2;
        private Label label1;
    }
}