using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using IDZ3.Models;
using Microsoft.EntityFrameworkCore;

namespace IDZ3
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            LoadReports();
        }

        private void LoadReports()
        {
            using (var context = new AppDbContext())
            {
                var films = context.Films
                    .Include(f => f.Studio)
                    .ToList();

                // Отчёт 1
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

                // Отчёт 2
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

                // Отчёт 3
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
        }

        /// <summary>
        /// Экспортирует выбранный отчёт в CSV-файл
        /// </summary>
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            // Определяем, какой DataGridView выбран
            DataGridView selectedGrid = null;
            string reportName = "";

            switch (cmbReportSelect.SelectedIndex)
            {
                case 0:
                    selectedGrid = dataGridView1;
                    reportName = "Полный список фильмов";
                    break;
                case 1:
                    selectedGrid = dataGridView2;
                    reportName = "Количество фильмов по студиям";
                    break;
                case 2:
                    selectedGrid = dataGridView3;
                    reportName = "Средний бюджет по студиям";
                    break;
                default:
                    MessageBox.Show("Выберите отчёт для экспорта", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // Проверяем, есть ли данные
            if (selectedGrid.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Диалог выбора места сохранения файла
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Сохранить отчёт как CSV";
            saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveDialog.FileName = $"Отчёт_{reportName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            saveDialog.DefaultExt = "csv";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportDataGridViewToCsv(selectedGrid, saveDialog.FileName);
                    MessageBox.Show($"Отчёт успешно сохранён!\n{saveDialog.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Сохраняет содержимое DataGridView в CSV-файл
        /// </summary>
        private void ExportDataGridViewToCsv(DataGridView grid, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // 1. Записываем заголовки столбцов
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                sb.Append(grid.Columns[i].HeaderText);
                if (i < grid.Columns.Count - 1)
                    sb.Append(";"); // разделитель — точка с запятой
            }
            sb.AppendLine();

            // 2. Записываем строки с данными
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue; // пропускаем пустую последнюю строку

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    object value = row.Cells[i].Value;
                    string cellValue = value?.ToString() ?? "";

                    // Если в значении есть точка с запятой или кавычка — оборачиваем в кавычки
                    if (cellValue.Contains(";") || cellValue.Contains("\""))
                    {
                        cellValue = "\"" + cellValue.Replace("\"", "\"\"") + "\"";
                    }

                    sb.Append(cellValue);
                    if (i < grid.Columns.Count - 1)
                        sb.Append(";");
                }
                sb.AppendLine();
            }

            // Сохраняем файл
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}