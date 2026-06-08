namespace IDZ3
{
    partial class ReportsForm
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
            lblReport1 = new Label();
            dataGridView1 = new DataGridView();
            lblReport2 = new Label();
            dataGridView2 = new DataGridView();
            lblReport3 = new Label();
            dataGridView3 = new DataGridView();
            cmbReportSelect = new ComboBox();
            btnExportCsv = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();

            // lblReport1
            lblReport1.AutoSize = true;
            lblReport1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReport1.Location = new Point(30, 60);
            lblReport1.Text = "Раздел 1: Полный список фильмов";

            // dataGridView1
            dataGridView1.Location = new Point(30, 90);
            dataGridView1.Size = new Size(800, 150);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // lblReport2
            lblReport2.AutoSize = true;
            lblReport2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReport2.Location = new Point(30, 260);
            lblReport2.Text = "Раздел 2: Количество фильмов по студиям";

            // dataGridView2
            dataGridView2.Location = new Point(30, 290);
            dataGridView2.Size = new Size(400, 150);
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;

            // lblReport3
            lblReport3.AutoSize = true;
            lblReport3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReport3.Location = new Point(30, 460);
            lblReport3.Text = "Раздел 3: Средний бюджет по студиям";

            // dataGridView3
            dataGridView3.Location = new Point(30, 490);
            dataGridView3.Size = new Size(400, 150);
            dataGridView3.ReadOnly = true;
            dataGridView3.AllowUserToAddRows = false;

            // cmbReportSelect (выпадающий список для выбора отчёта)
            cmbReportSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportSelect.Items.AddRange(new object[] {
                "Раздел 1: Полный список фильмов",
                "Раздел 2: Количество фильмов по студиям",
                "Раздел 3: Средний бюджет по студиям"
            });
            cmbReportSelect.Location = new Point(30, 20);
            cmbReportSelect.Name = "cmbReportSelect";
            cmbReportSelect.Size = new Size(250, 28);
            cmbReportSelect.SelectedIndex = 0;

            // btnExportCsv (кнопка экспорта)
            btnExportCsv.Location = new Point(300, 18);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(150, 32);
            btnExportCsv.Text = "Экспорт в CSV";
            btnExportCsv.UseVisualStyleBackColor = true;
            btnExportCsv.Click += btnExportCsv_Click;

            // ReportsForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(900, 700);
            Controls.Add(btnExportCsv);
            Controls.Add(cmbReportSelect);
            Controls.Add(dataGridView3);
            Controls.Add(lblReport3);
            Controls.Add(dataGridView2);
            Controls.Add(lblReport2);
            Controls.Add(dataGridView1);
            Controls.Add(lblReport1);
            Text = "Отчёты";
            StartPosition = FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblReport1;
        private DataGridView dataGridView1;
        private Label lblReport2;
        private DataGridView dataGridView2;
        private Label lblReport3;
        private DataGridView dataGridView3;
        private ComboBox cmbReportSelect;
        private Button btnExportCsv;
    }
}