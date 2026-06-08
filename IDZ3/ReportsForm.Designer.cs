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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // lblReport1
            // 
            lblReport1.AutoSize = true;
            lblReport1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReport1.Location = new Point(30, 20);
            lblReport1.Name = "lblReport1";
            lblReport1.Size = new Size(304, 23);
            lblReport1.TabIndex = 5;
            lblReport1.Text = "Раздел 1: Полный список фильмов";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(30, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(770, 150);
            dataGridView1.TabIndex = 4;
            // 
            // lblReport2
            // 
            lblReport2.AutoSize = true;
            lblReport2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReport2.Location = new Point(30, 220);
            lblReport2.Name = "lblReport2";
            lblReport2.Size = new Size(370, 23);
            lblReport2.TabIndex = 3;
            lblReport2.Text = "Раздел 2: Количество фильмов по студиям";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ColumnHeadersHeight = 29;
            dataGridView2.Location = new Point(30, 250);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(770, 150);
            dataGridView2.TabIndex = 2;
            // 
            // lblReport3
            // 
            lblReport3.AutoSize = true;
            lblReport3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReport3.Location = new Point(30, 420);
            lblReport3.Name = "lblReport3";
            lblReport3.Size = new Size(337, 23);
            lblReport3.TabIndex = 1;
            lblReport3.Text = "Раздел 3: Средний бюджет по студиям";
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.ColumnHeadersHeight = 29;
            dataGridView3.Location = new Point(30, 450);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(770, 150);
            dataGridView3.TabIndex = 0;
            // 
            // ReportsForm
            // 
            ClientSize = new Size(900, 650);
            Controls.Add(dataGridView3);
            Controls.Add(lblReport3);
            Controls.Add(dataGridView2);
            Controls.Add(lblReport2);
            Controls.Add(dataGridView1);
            Controls.Add(lblReport1);
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Отчёты";
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
    }
}