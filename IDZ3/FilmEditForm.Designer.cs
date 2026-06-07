namespace IDZ3
{
    partial class FilmEditForm
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
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            numBudget = new NumericUpDown();
            label3 = new Label();
            cmbStudio = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numBudget).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(219, 58);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 0;
            label1.Text = "Название фильма:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(219, 81);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(184, 27);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 124);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 2;
            label2.Text = "Бюджет (млн $):";
            // 
            // numBudget
            // 
            numBudget.DecimalPlaces = 2;
            numBudget.Location = new Point(220, 156);
            numBudget.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numBudget.Name = "numBudget";
            numBudget.Size = new Size(183, 27);
            numBudget.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 204);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 4;
            label3.Text = "Киностудия:";
            // 
            // cmbStudio
            // 
            cmbStudio.FormattingEnabled = true;
            cmbStudio.Location = new Point(219, 227);
            cmbStudio.Name = "cmbStudio";
            cmbStudio.Size = new Size(184, 28);
            cmbStudio.TabIndex = 5;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(206, 296);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 6;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(318, 296);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FilmEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cmbStudio);
            Controls.Add(label3);
            Controls.Add(numBudget);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "FilmEditForm";
            Text = "FilmEditForm";
            ((System.ComponentModel.ISupportInitialize)numBudget).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private NumericUpDown numBudget;
        private Label label3;
        private ComboBox cmbStudio;
        private Button btnOk;
        private Button btnCancel;
    }
}