using System;
using System.Windows.Forms;

namespace IDZ3
{
    public partial class StudioEditForm : Form
    {
        public string StudioName => txtName.Text.Trim();

        public StudioEditForm()
        {
            InitializeComponent();
            Text = "Добавление студии";
        }

        public StudioEditForm(string currentName)
        {
            InitializeComponent();
            Text = "Редактирование студии";
            txtName.Text = currentName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название студии!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}