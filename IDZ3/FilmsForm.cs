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
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new AppDbContext())
            {
                var films = context.Films
                    .Include(f => f.Studio)
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
                    LoadData();
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
                    LoadData();
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
                        LoadData();
                    }
                }
            }
        }
    }
}