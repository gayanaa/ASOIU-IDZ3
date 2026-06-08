using IDZ3.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace IDZ3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            EnsureDatabaseCreated();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        private static void EnsureDatabaseCreated()
        {
            using (var context = new AppDbContext())
            {
                bool created = context.Database.EnsureCreated();

                if (created)
                {
                    // Пытаемся загрузить из CSV-файлов
                    bool loadedFromCsv = LoadDataFromCsv(context);

                    // Если CSV-файлов нет, загружаем данные по умолчанию
                    if (!loadedFromCsv)
                    {
                        LoadDefaultData(context);
                    }
                }
            }
        }

        /// <summary>
        /// Загружает данные из CSV-файлов (studios.csv и films.csv)
        /// </summary>
        private static bool LoadDataFromCsv(AppDbContext context)
        {
            string studiosPath = "studios.csv";
            string filmsPath = "films.csv";

            // Проверяем, существуют ли файлы
            if (!File.Exists(studiosPath) || !File.Exists(filmsPath))
                return false;

            // Загружаем студии
            var studios = new List<Studio>();
            var lines = File.ReadAllLines(studiosPath);

            // Пропускаем заголовок (первую строку), если он есть
            int startLine = lines[0].Contains("Name") || lines[0].Contains("Название") ? 1 : 0;

            for (int i = startLine; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                string name = parts[0].Trim();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    studios.Add(new Studio { Name = name });
                }
            }

            if (studios.Any())
            {
                context.Studios.AddRange(studios);
                context.SaveChanges();
            }

            // Загружаем фильмы
            var films = new List<Film>();
            lines = File.ReadAllLines(filmsPath);
            startLine = lines[0].Contains("Title") || lines[0].Contains("Название") ? 1 : 0;

            // Получаем словарь студий для быстрого поиска Id по названию
            var studioDict = context.Studios.ToDictionary(s => s.Name, s => s.Id);

            for (int i = startLine; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    string title = parts[0].Trim();
                    string studioName = parts[1].Trim();
                    decimal budget;

                    bool budgetOk = decimal.TryParse(parts[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out budget);

                    if (!string.IsNullOrWhiteSpace(title) && studioDict.ContainsKey(studioName) && budgetOk && budget >= 0)
                    {
                        films.Add(new Film
                        {
                            Title = title,
                            StudioId = studioDict[studioName],
                            BudgetMln = budget
                        });
                    }
                }
            }

            if (films.Any())
            {
                context.Films.AddRange(films);
                context.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Загружает начальные данные по умолчанию (если CSV нет)
        /// </summary>
        private static void LoadDefaultData(AppDbContext context)
        {
            // Добавляем студии
            var studios = new List<Studio>
            {
                new Studio { Name = "Warner Bros" },
                new Studio { Name = "Universal Pictures" },
                new Studio { Name = "Paramount Pictures" },
                new Studio { Name = "20th Century Studios" },
                new Studio { Name = "Sony Pictures" }
            };
            context.Studios.AddRange(studios);
            context.SaveChanges();

            // Добавляем фильмы
            var warnerId = context.Studios.First(s => s.Name == "Warner Bros").Id;
            var universalId = context.Studios.First(s => s.Name == "Universal Pictures").Id;
            var paramountId = context.Studios.First(s => s.Name == "Paramount Pictures").Id;
            var foxId = context.Studios.First(s => s.Name == "20th Century Studios").Id;
            var sonyId = context.Studios.First(s => s.Name == "Sony Pictures").Id;

            var films = new List<Film>
            {
                new Film { Title = "Inception", BudgetMln = 160, StudioId = warnerId },
                new Film { Title = "The Dark Knight", BudgetMln = 185, StudioId = warnerId },
                new Film { Title = "Interstellar", BudgetMln = 165, StudioId = warnerId },
                new Film { Title = "Jurassic Park", BudgetMln = 63, StudioId = universalId },
                new Film { Title = "Jurassic World", BudgetMln = 150, StudioId = universalId },
                new Film { Title = "Oppenheimer", BudgetMln = 100, StudioId = universalId },
                new Film { Title = "Forrest Gump", BudgetMln = 55, StudioId = paramountId },
                new Film { Title = "Titanic", BudgetMln = 200, StudioId = paramountId },
                new Film { Title = "Avatar", BudgetMln = 237, StudioId = foxId },
                new Film { Title = "Avatar: The Way of Water", BudgetMln = 350, StudioId = foxId },
                new Film { Title = "Spider-Man: No Way Home", BudgetMln = 200, StudioId = sonyId },
                new Film { Title = "Jumanji: Welcome to the Jungle", BudgetMln = 90, StudioId = sonyId }
            };
            context.Films.AddRange(films);
            context.SaveChanges();
        }
    }
}