using System;
using System.Linq;
using System.Windows.Forms;
using IDZ3.Models;

namespace IDZ3
{
    public partial class FilmEditForm : Form
    {
        private AppDbContext _context;
        private int? _editFilmId;

        public string FilmTitle => txtTitle.Text.Trim();
        public decimal BudgetMln => numBudget.Value;
        public int SelectedStudioId => (int)cmbStudio.SelectedValue;

        public FilmEditForm(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            Text = "Добавление фильма";
            LoadStudios();
        }

        public FilmEditForm(AppDbContext context, Film film)
        {
            InitializeComponent();
            _context = context;
            _editFilmId = film.Id;
            Text = "Редактирование фильма";
            LoadStudios();

            txtTitle.Text = film.Title;
            numBudget.Value = film.BudgetMln;
            cmbStudio.SelectedValue = film.StudioId;
        }

        private void LoadStudios()
        {
            var studios = _context.Studios.OrderBy(s => s.Name).ToList();
            cmbStudio.DataSource = studios;
            cmbStudio.DisplayMember = "Name";
            cmbStudio.ValueMember = "Id";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название фильма!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numBudget.Value < 0)
            {
                MessageBox.Show("Бюджет не может быть отрицательным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStudio.SelectedItem == null)
            {
                MessageBox.Show("Выберите киностудию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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