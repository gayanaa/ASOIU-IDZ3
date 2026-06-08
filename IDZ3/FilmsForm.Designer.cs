using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace IDZ3
{
    partial class FilmsForm
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
            dgvFilms = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnClearSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFilms).BeginInit();
            SuspendLayout();

            // dgvFilms
            dgvFilms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFilms.Location = new Point(30, 80);
            dgvFilms.Name = "dgvFilms";
            dgvFilms.ReadOnly = true;
            dgvFilms.AllowUserToAddRows = false;
            dgvFilms.RowHeadersWidth = 51;
            dgvFilms.Size = new Size(640, 250);
            dgvFilms.TabIndex = 0;

            // lblSearch
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(30, 30);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(60, 20);
            lblSearch.Text = "Поиск:";

            // txtSearch
            txtSearch.Location = new Point(100, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;

            // btnClearSearch
            btnClearSearch.Location = new Point(320, 27);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(100, 30);
            btnClearSearch.Text = "Очистить";
            btnClearSearch.UseVisualStyleBackColor = true;
            btnClearSearch.Click += btnClearSearch_Click;

            // btnAdd
            btnAdd.Location = new Point(30, 350);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 40);
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;

            // btnEdit
            btnEdit.Location = new Point(200, 350);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 40);
            btnEdit.Text = "Изменить";
            btnEdit.Click += btnEdit_Click;

            // btnDelete
            btnDelete.Location = new Point(370, 350);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;

            // FilmsForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 420);
            Controls.Add(btnClearSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvFilms);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FilmsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление фильмами";
            ((System.ComponentModel.ISupportInitialize)dgvFilms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvFilms;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnClearSearch;
    }
}