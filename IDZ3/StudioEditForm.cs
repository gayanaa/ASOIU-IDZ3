using System;
using System.Windows.Forms;

namespace IDZ3
{
    public partial class StudioEditForm : Form
    {
        /// <summary>
        /// Свойство, которое возвращает введённое название студии
        /// </summary>
        public string StudioName => txtName.Text.Trim();

        /// <summary>
        /// Конструктор для добавления новой студии (без параметров)
        /// </summary>
        public StudioEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление студии";
        }

        /// <summary>
        /// Конструктор для редактирования существующей студии
        /// </summary>
        /// <param name="currentName">Текущее название студии</param>
        public StudioEditForm(string currentName)
        {
            InitializeComponent();
            this.Text = "Редактирование студии";
            txtName.Text = currentName;
        }

        /// <summary>
        /// Кнопка OK — проверяем ввод и закрываем форму
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Проверяем, что название не пустое
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название студии!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Всё хорошо — закрываем форму с результатом OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Кнопка Отмена — закрываем форму без сохранения
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
    }
}