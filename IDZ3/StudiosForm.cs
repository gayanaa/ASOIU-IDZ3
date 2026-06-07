using System;
using System.Linq;
using System.Windows.Forms;
using IDZ3.Models;
using Microsoft.EntityFrameworkCore;

namespace IDZ3
{
    public partial class StudiosForm : Form
    {
        // Переменная для работы с базой данных
        private AppDbContext _context;

        public StudiosForm()
        {
            InitializeComponent();

            // Создаём контекст базы данных
            _context = new AppDbContext();

            // Загружаем данные в таблицу
            LoadData();
        }

        /// <summary>
        /// Загружает список всех студий из базы данных и показывает их в таблице
        /// </summary>
        private void LoadData()
        {
            // Получаем все студии из БД, сортируем по Id
            var studios = _context.Studios
                .OrderBy(s => s.Id)
                .ToList();

            // Привязываем данные к DataGridView
            dgvStudios.DataSource = studios;

            // Настраиваем заголовки столбцов (чтобы было понятнее)
            if (dgvStudios.Columns.Contains("Id"))
                dgvStudios.Columns["Id"].HeaderText = "№";
            if (dgvStudios.Columns.Contains("Name"))
                dgvStudios.Columns["Name"].HeaderText = "Название студии";

            // Скрываем колонку Films (она нам здесь не нужна)
            if (dgvStudios.Columns.Contains("Films"))
                dgvStudios.Columns["Films"].Visible = false;
        }

        /// <summary>
        /// Кнопка "Добавить" — открывает форму для создания новой студии
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Создаём форму для редактирования (в режиме добавления)
            var editForm = new StudioEditForm();

            // Если пользователь нажал "Сохранить" в той форме
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Создаём новую студию
                var studio = new Studio
                {
                    Name = editForm.StudioName
                };

                // Добавляем в базу данных
                _context.Studios.Add(studio);
                _context.SaveChanges();

                // Обновляем таблицу
                LoadData();
            }
        }

        /// <summary>
        /// Кнопка "Изменить" — открывает форму для редактирования выбранной студии
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Получаем выбранную строку в таблице
            if (dgvStudios.CurrentRow == null)
            {
                MessageBox.Show("Выберите студию для редактирования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем объект студии из выбранной строки
            var studio = (Studio)dgvStudios.CurrentRow.DataBoundItem;

            // Открываем форму редактирования с текущим названием
            var editForm = new StudioEditForm(studio.Name);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Обновляем название студии
                studio.Name = editForm.StudioName;

                // Сохраняем изменения в БД
                _context.SaveChanges();

                // Обновляем таблицу
                LoadData();
            }
        }

        /// <summary>
        /// Кнопка "Удалить" — удаляет выбранную студию (с проверкой, есть ли фильмы)
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана студия
            if (dgvStudios.CurrentRow == null)
            {
                MessageBox.Show("Выберите студию для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var studio = (Studio)dgvStudios.CurrentRow.DataBoundItem;

            // Загружаем информацию о фильмах этой студии из БД
            _context.Entry(studio).Collection(s => s.Films).Load();

            // Проверяем, есть ли у студии фильмы
            if (studio.Films.Any())
            {
                MessageBox.Show(
                    "Нельзя удалить студию, у которой есть фильмы!\n" +
                    "Сначала удалите все фильмы этой студии.",
                    "Ошибка удаления",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Спрашиваем подтверждение
            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить студию \"{studio.Name}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Удаляем студию из БД
                _context.Studios.Remove(studio);
                _context.SaveChanges();

                // Обновляем таблицу
                LoadData();
            }
        }

        /// <summary>
        /// Закрываем соединение с БД при закрытии формы
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose(); // Закрываем соединение с базой данных
        }
    }
}