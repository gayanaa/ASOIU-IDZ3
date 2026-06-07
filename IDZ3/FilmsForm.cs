using System;
using System.Linq;
using System.Windows.Forms;
using IDZ3.Models;
using Microsoft.EntityFrameworkCore;

namespace IDZ3
{
    public partial class FilmsForm : Form
    {
        private AppDbContext _context;

        public FilmsForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadData();
        }

        /// <summary>
        /// Загружает список фильмов с названиями студий (используя Include)
        /// </summary>
        private void LoadData()
        {
            // Include( f => f.Studio) — загружает данные о студии для каждого фильма
            var films = _context.Films
                .Include(f => f.Studio)  // Важно! Без этого Studio будет null
                .OrderBy(f => f.Id)
                .Select(f => new
                {
                    f.Id,
                    f.Title,
                    Бюджет_млн = f.BudgetMln,
                    Киностудия = f.Studio != null ? f.Studio.Name : "—"
                })
                .ToList();

            dgvFilms.DataSource = films;

            // Настраиваем заголовки
            if (dgvFilms.Columns.Contains("Id"))
                dgvFilms.Columns["Id"].HeaderText = "№";
            if (dgvFilms.Columns.Contains("Title"))
                dgvFilms.Columns["Title"].HeaderText = "Название фильма";
            if (dgvFilms.Columns.Contains("Бюджет_млн"))
                dgvFilms.Columns["Бюджет_млн"].HeaderText = "Бюджет (млн $)";
            if (dgvFilms.Columns.Contains("Киностудия"))
                dgvFilms.Columns["Киностудия"].HeaderText = "Киностудия";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new FilmEditForm(_context);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                var film = new Film
                {
                    Title = editForm.FilmTitle,
                    BudgetMln = editForm.BudgetMln,
                    StudioId = editForm.SelectedStudioId
                };

                _context.Films.Add(film);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFilms.CurrentRow == null)
            {
                MessageBox.Show("Выберите фильм для редактирования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем Id выбранного фильма (через динамический тип)
            dynamic item = dgvFilms.CurrentRow.DataBoundItem;
            int filmId = item.Id;

            var film = _context.Films.Find(filmId);

            if (film == null)
            {
                MessageBox.Show("Фильм не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var editForm = new FilmEditForm(_context, film);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                film.Title = editForm.FilmTitle;
                film.BudgetMln = editForm.BudgetMln;
                film.StudioId = editForm.SelectedStudioId;

                _context.SaveChanges();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFilms.CurrentRow == null)
            {
                MessageBox.Show("Выберите фильм для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic item = dgvFilms.CurrentRow.DataBoundItem;
            int filmId = item.Id;

            var film = _context.Films.Find(filmId);

            if (film == null) return;

            var result = MessageBox.Show(
                $"Удалить фильм \"{film.Title}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _context.Films.Remove(film);
                _context.SaveChanges();
                LoadData();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}