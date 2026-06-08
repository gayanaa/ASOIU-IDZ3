namespace IDZ3
{
    partial class StudiosForm
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
            dgvStudios = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudios).BeginInit();
            SuspendLayout();

            // dgvStudios
            dgvStudios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudios.Location = new Point(30, 30);
            dgvStudios.Name = "dgvStudios";
            dgvStudios.ReadOnly = true;
            dgvStudios.AllowUserToAddRows = false;
            dgvStudios.RowHeadersWidth = 51;
            dgvStudios.Size = new Size(540, 250);
            dgvStudios.TabIndex = 0;

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

            // StudiosForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 370);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvStudios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StudiosForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление киностудиями";
            ((System.ComponentModel.ISupportInitialize)dgvStudios).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dgvStudios;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}