using IDZ3.Models;  // Подключаем наши модели

namespace IDZ3
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа в приложение.
        /// Программа начинается здесь.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1. Создаём базу данных, если её нет
            EnsureDatabaseCreated();

            // 2. Настраиваем внешний вид приложения (стили кнопок и т.д.)
            ApplicationConfiguration.Initialize();

            // 3. Запускаем главное окно
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Проверяет, существует ли база данных.
        /// Если нет — создаёт её автоматически.
        /// </summary>
        private static void EnsureDatabaseCreated()
        {
            // using (...) означает: после выполнения кода в скобках соединение с БД закроется
            using (var context = new AppDbContext())
            {
                // EnsureCreated() — волшебный метод:
                // если БД не существует → создаёт её и все таблицы
                // если существует → ничего не делает
                bool created = context.Database.EnsureCreated();

                if (created)
                {
                    System.Console.WriteLine("База данных успешно создана!");
                }
            }
        }
    }
}