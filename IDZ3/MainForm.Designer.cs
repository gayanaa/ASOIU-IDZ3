namespace IDZ3
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStudios = new Button();
            btnFilms = new Button();
            btnReports = new Button();
            SuspendLayout();
            // 
            // btnStudios
            // 
            btnStudios.Location = new Point(325, 97);
            btnStudios.Name = "btnStudios";
            btnStudios.Size = new Size(150, 40);
            btnStudios.TabIndex = 0;
            btnStudios.Text = "Киностудии";
            btnStudios.UseVisualStyleBackColor = true;
            btnStudios.Click += btnStudios_Click;
            // 
            // btnFilms
            // 
            btnFilms.Location = new Point(325, 153);
            btnFilms.Name = "btnFilms";
            btnFilms.Size = new Size(150, 40);
            btnFilms.TabIndex = 1;
            btnFilms.Text = "Фильмы";
            btnFilms.UseVisualStyleBackColor = true;
            btnFilms.Click += btnFilms_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(325, 209);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(150, 40);
            btnReports.TabIndex = 2;
            btnReports.Text = "Отчёты";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReports);
            Controls.Add(btnFilms);
            Controls.Add(btnStudios);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStudios;
        private Button btnFilms;
        private Button btnReports;
    }
}