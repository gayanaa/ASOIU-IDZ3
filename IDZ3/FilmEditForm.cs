using System;
using System.Linq;
using System.Windows.Forms;
using IDZ3.Models;

namespace IDZ3
{
    public partial class FilmEditForm : Form
    {
        private int? _editFilmId;
        private System.Collections.Generic.List<Studio> _studios;

        public string FilmTitle => txtTitle.Text.Trim();
        public decimal BudgetMln => numBudget.Value;
        public int SelectedStudioId => (int)cmbStudio.SelectedValue;

        public FilmEditForm(AppDbContext context)
        {
            InitializeComponent();
            Text = "Добавление фильма";
            LoadStudios(context);
        }

        public FilmEditForm(AppDbContext context, Film film)
        {
            InitializeComponent();
            _editFilmId = film.Id;
            Text = "Редактирование фильма";
            LoadStudios(context);

            txtTitle.Text = film.Title;
            numBudget.Value = film.BudgetMln;
            cmbStudio.SelectedValue = film.StudioId;
        }

        private void LoadStudios(AppDbContext context)
        {
            _studios = context.Studios.OrderBy(s => s.Name).ToList();
            cmbStudio.DataSource = _studios;
            cmbStudio.DisplayMember = "Name";
            cmbStudio.ValueMember = "Id";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Проверка 1: название не пустое
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название фильма!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка 2: бюджет не отрицательный
            if (numBudget.Value < 0)
            {
                MessageBox.Show("Бюджет не может быть отрицательным!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка 3: бюджет не превышает 500 млн
            if (numBudget.Value > 500)
            {
                MessageBox.Show("Бюджет не может превышать 500 миллионов долларов!\n" +
                    "Пожалуйста, введите корректное значение.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка 4: выбрана студия
            if (cmbStudio.SelectedItem == null)
            {
                MessageBox.Show("Выберите киностудию!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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