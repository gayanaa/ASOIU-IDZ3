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
            SuspendLayout();

            // btnStudios
            btnStudios.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStudios.Location = new Point(100, 50);
            btnStudios.Name = "btnStudios";
            btnStudios.Size = new Size(200, 50);
            btnStudios.TabIndex = 0;
            btnStudios.Text = "Киностудии";
            btnStudios.UseVisualStyleBackColor = true;
            btnStudios.Click += btnStudios_Click;

            // btnFilms
            btnFilms.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFilms.Location = new Point(100, 120);
            btnFilms.Name = "btnFilms";
            btnFilms.Size = new Size(200, 50);
            btnFilms.TabIndex = 1;
            btnFilms.Text = "Фильмы";
            btnFilms.UseVisualStyleBackColor = true;
            btnFilms.Click += btnFilms_Click;

            // btnReports
            btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReports.Location = new Point(100, 190);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(200, 50);
            btnReports.TabIndex = 2;
            btnReports.Text = "Отчёты";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;

            // MainForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(btnReports);
            Controls.Add(btnFilms);
            Controls.Add(btnStudios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление киностудиями и фильмами";
            ResumeLayout(false);
        }

        private Button btnStudios;
        private Button btnFilms;
        private Button btnReports;
    }
}