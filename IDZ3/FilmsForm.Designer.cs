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
            ((System.ComponentModel.ISupportInitialize)dgvFilms).BeginInit();
            SuspendLayout();

            // dgvFilms
            dgvFilms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFilms.Location = new Point(30, 30);
            dgvFilms.Name = "dgvFilms";
            dgvFilms.ReadOnly = true;
            dgvFilms.AllowUserToAddRows = false;
            dgvFilms.RowHeadersWidth = 51;
            dgvFilms.Size = new Size(640, 250);
            dgvFilms.TabIndex = 0;

            // btnAdd
            btnAdd.Location = new Point(30, 300);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // btnEdit
            btnEdit.Location = new Point(200, 300);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 40);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;

            // btnDelete
            btnDelete.Location = new Point(370, 300);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // FilmsForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 370);
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
        }

        private DataGridView dgvFilms;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}