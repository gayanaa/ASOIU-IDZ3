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

        // Свойства, которые возвращают введённые значения
        public string FilmTitle => txtTitle.Text.Trim();
        public decimal BudgetMln => numBudget.Value;
        public int SelectedStudioId => (int)cmbStudio.SelectedValue;

        /// <summary>
        /// Конструктор для ДОБАВЛЕНИЯ нового фильма
        /// </summary>
        public FilmEditForm(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            this.Text = "Добавление фильма";
            LoadStudios();
            btnOk.Click += btnOk_Click;
            btnCancel.Click += btnCancel_Click;
        }

        /// <summary>
        /// Конструктор для РЕДАКТИРОВАНИЯ существующего фильма
        /// </summary>
        public FilmEditForm(AppDbContext context, Film film)
        {
            InitializeComponent();
            _context = context;
            _editFilmId = film.Id;
            this.Text = "Редактирование фильма";
            LoadStudios();

            // Заполняем поля текущими значениями
            txtTitle.Text = film.Title;
            numBudget.Value = film.BudgetMln;
            cmbStudio.SelectedValue = film.StudioId;
            btnOk.Click += btnOk_Click;
            btnCancel.Click += btnCancel_Click;
        }

        /// <summary>
        /// Загружает список студий в выпадающий список
        /// </summary>
        private void LoadStudios()
        {
            var studios = _context.Studios.OrderBy(s => s.Name).ToList();
            cmbStudio.DataSource = studios;
            cmbStudio.DisplayMember = "Name";
            cmbStudio.ValueMember = "Id";
        }

        /// <summary>
        /// Кнопка OK - проверяем данные и закрываем форму
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Проверка: название не пустое
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название фильма!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка: бюджет не отрицательный (NumericUpDown уже не даст, но на всякий случай)
            if (numBudget.Value < 0)
            {
                MessageBox.Show("Бюджет не может быть отрицательным!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка: выбрана ли студия
            if (cmbStudio.SelectedItem == null)
            {
                MessageBox.Show("Выберите киностудию!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Всё хорошо - закрываем форму с результатом OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Кнопка Отмена - закрываем форму без сохранения
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}