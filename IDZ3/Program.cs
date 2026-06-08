using IDZ3.Models;
using System.Linq;
using System.Collections.Generic;

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
                    // Добавляем начальные данные - студии
                    if (!context.Studios.Any())
                    {
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
                    }

                    // Добавляем начальные данные - фильмы (12 штук)
                    if (!context.Films.Any())
                    {
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
        }
    }
}