using System;
using System.Linq;
using System.Windows.Forms;
using IDZ3.Models;
using Microsoft.EntityFrameworkCore;

namespace IDZ3
{
    public partial class FilmsForm : Form
    {
        public FilmsForm()
        {
            InitializeComponent();
            LoadData("");
        }

        /// <summary>
        /// Загружает фильмы из базы данных.
        /// Если передан поисковый запрос, фильтрует по названию.
        /// </summary>
        /// <param name="searchText">Текст для поиска (регистр не важен)</param>
        private void LoadData(string searchText)
        {
            using (var context = new AppDbContext())
            {
                // Базовый запрос
                var query = context.Films
                    .Include(f => f.Studio)
                    .AsQueryable();

                // Если есть текст поиска - фильтруем
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query = query.Where(f => f.Title.ToLower().Contains(searchText.ToLower()));
                }

                // Выполняем запрос
                var films = query
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

                // Настройка заголовков столбцов
                if (dgvFilms.Columns.Contains("Id"))
                    dgvFilms.Columns["Id"].HeaderText = "№";
                if (dgvFilms.Columns.Contains("Title"))
                    dgvFilms.Columns["Title"].HeaderText = "Название фильма";
                if (dgvFilms.Columns.Contains("Бюджет_млн"))
                    dgvFilms.Columns["Бюджет_млн"].HeaderText = "Бюджет (млн $)";
                if (dgvFilms.Columns.Contains("Киностудия"))
                    dgvFilms.Columns["Киностудия"].HeaderText = "Киностудия";
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле поиска.
        /// Каждое нажатие клавиши обновляет таблицу.
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        /// <summary>
        /// Очищает поле поиска и показывает все фильмы.
        /// </summary>
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadData("");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                var form = new FilmEditForm(context);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var film = new Film
                    {
                        Title = form.FilmTitle,
                        BudgetMln = form.BudgetMln,
                        StudioId = form.SelectedStudioId
                    };
                    context.Films.Add(film);
                    context.SaveChanges();
                    LoadData(txtSearch.Text);
                }
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

            dynamic item = dgvFilms.CurrentRow.DataBoundItem;
            int filmId = item.Id;

            using (var context = new AppDbContext())
            {
                var film = context.Films.Find(filmId);
                if (film == null) return;

                var form = new FilmEditForm(context, film);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    film.Title = form.FilmTitle;
                    film.BudgetMln = form.BudgetMln;
                    film.StudioId = form.SelectedStudioId;
                    context.SaveChanges();
                    LoadData(txtSearch.Text);
                }
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

            var result = MessageBox.Show($"Удалить фильм?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var context = new AppDbContext())
                {
                    var film = context.Films.Find(filmId);
                    if (film != null)
                    {
                        context.Films.Remove(film);
                        context.SaveChanges();
                        LoadData(txtSearch.Text);
                    }
                }
            }
        }
    }
}