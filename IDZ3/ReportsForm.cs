using System;
using System.Linq;
using System.Windows.Forms;
using IDZ3.Models;
using Microsoft.EntityFrameworkCore;

namespace IDZ3
{
    public partial class ReportsForm : Form
    {
        private AppDbContext _context;

        public ReportsForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadReports();
        }

        private void LoadReports()
        {
            // Загружаем данные в память (для маленькой БД это нормально)
            var films = _context.Films
                .Include(f => f.Studio)
                .ToList();

            // Отчёт 1: все фильмы с названием студии
            var report1 = films
                .OrderBy(f => f.Title)
                .Select(f => new
                {
                    Название = f.Title,
                    Киностудия = f.Studio?.Name ?? "—",
                    Бюджет_млн = f.BudgetMln
                })
                .ToList();

            dataGridView1.DataSource = report1;

            // Отчёт 2: количество фильмов по студиям
            var report2 = films
                .Where(f => f.Studio != null)
                .GroupBy(f => f.Studio.Name)
                .Select(g => new
                {
                    Киностудия = g.Key,
                    Количество_фильмов = g.Count()
                })
                .OrderBy(r => r.Киностудия)
                .ToList();

            dataGridView2.DataSource = report2;

            // Отчёт 3: средний бюджет по студиям (сортировка по убыванию)
            var report3 = films
                .Where(f => f.Studio != null)
                .GroupBy(f => f.Studio.Name)
                .Select(g => new
                {
                    Киностудия = g.Key,
                    Средний_бюджет_млн = Math.Round(g.Average(f => f.BudgetMln), 2)
                })
                .OrderByDescending(r => r.Средний_бюджет_млн)
                .ToList();

            dataGridView3.DataSource = report3;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}