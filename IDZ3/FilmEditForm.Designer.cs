namespace IDZ3
{
    partial class FilmEditForm
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
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblBudget = new Label();
            numBudget = new NumericUpDown();
            lblStudio = new Label();
            cmbStudio = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numBudget).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(138, 20);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Название фильма:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(30, 60);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 27);
            txtTitle.TabIndex = 6;
            // 
            // lblBudget
            // 
            lblBudget.AutoSize = true;
            lblBudget.Location = new Point(30, 100);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new Size(120, 20);
            lblBudget.TabIndex = 5;
            lblBudget.Text = "Бюджет (млн $):";
            // 
            // numBudget
            // 
            numBudget.DecimalPlaces = 2;
            numBudget.Location = new Point(30, 130);
            numBudget.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numBudget.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numBudget.Name = "numBudget";
            numBudget.Size = new Size(150, 27);
            numBudget.TabIndex = 4;
            // 
            // lblStudio
            // 
            lblStudio.AutoSize = true;
            lblStudio.Location = new Point(30, 170);
            lblStudio.Name = "lblStudio";
            lblStudio.Size = new Size(93, 20);
            lblStudio.TabIndex = 3;
            lblStudio.Text = "Киностудия:";
            // 
            // cmbStudio
            // 
            cmbStudio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudio.Location = new Point(30, 200);
            cmbStudio.Name = "cmbStudio";
            cmbStudio.Size = new Size(300, 28);
            cmbStudio.TabIndex = 2;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(80, 250);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 35);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(200, 250);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 35);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FilmEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 310);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cmbStudio);
            Controls.Add(lblStudio);
            Controls.Add(numBudget);
            Controls.Add(lblBudget);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FilmEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление фильма";
            ((System.ComponentModel.ISupportInitialize)numBudget).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblBudget;
        private NumericUpDown numBudget;
        private Label lblStudio;
        private ComboBox cmbStudio;
        private Button btnOk;
        private Button btnCancel;
    }
}