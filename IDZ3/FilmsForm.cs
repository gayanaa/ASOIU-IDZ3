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

        private void LoadData()
        {
            var films = _context.Films
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FilmEditForm(_context);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var film = new Film
                {
                    Title = form.FilmTitle,
                    BudgetMln = form.BudgetMln,
                    StudioId = form.SelectedStudioId
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
                MessageBox.Show("Выберите фильм для редактирования");
                return;
            }

            dynamic item = dgvFilms.CurrentRow.DataBoundItem;
            int filmId = item.Id;

            var film = _context.Films.Find(filmId);
            if (film == null) return;

            var form = new FilmEditForm(_context, film);
            if (form.ShowDialog() == DialogResult.OK)
            {
                film.Title = form.FilmTitle;
                film.BudgetMln = form.BudgetMln;
                film.StudioId = form.SelectedStudioId;
                _context.SaveChanges();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFilms.CurrentRow == null)
            {
                MessageBox.Show("Выберите фильм для удаления");
                return;
            }

            dynamic item = dgvFilms.CurrentRow.DataBoundItem;
            int filmId = item.Id;

            var film = _context.Films.Find(filmId);
            if (film == null) return;

            if (MessageBox.Show($"Удалить фильм \"{film.Title}\"?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
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