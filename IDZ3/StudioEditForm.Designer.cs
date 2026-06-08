namespace IDZ3
{
    partial class StudioEditForm
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
            lblName = new Label();
            txtName = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new Point(30, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(120, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Название студии:";

            // txtName
            txtName.Location = new Point(30, 60);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 1;

            // btnOk
            btnOk.Location = new Point(80, 110);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 35);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;  // ← ЭТА СТРОКА ДОБАВЛЕНА

            // btnCancel
            btnCancel.Location = new Point(190, 110);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 35);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;  // ← ЭТА СТРОКА ДОБАВЛЕНА

            // StudioEditForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 170);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudioEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление студии";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblName;
        private TextBox txtName;
        private Button btnOk;
        private Button btnCancel;
    }
}