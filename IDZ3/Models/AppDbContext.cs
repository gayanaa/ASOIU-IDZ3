using Microsoft.EntityFrameworkCore;

namespace IDZ3.Models
{
    /// <summary>
    /// Контекст базы данных.
    /// Это главный класс, через который мы будем работать с БД.
    /// Он знает о всех таблицах и умеет создавать базу данных.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Таблица студий. DbSet<Studio> означает "набор объектов Studio".
        /// Через это свойство мы будем добавлять, удалять и искать студии.
        /// </summary>
        public DbSet<Studio> Studios { get; set; }

        /// <summary>
        /// Таблица фильмов.
        /// </summary>
        public DbSet<Film> Films { get; set; }

        /// <summary>
        /// Имя файла базы данных. Файл будет создан в папке с программой.
        /// </summary>
        private static readonly string DbPath = "studios_films.db";

        /// <summary>
        /// Настройка подключения к базе данных.
        /// Этот метод вызывает EF Core, когда нужно узнать, как подключаться к БД.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Говорим EF Core: используй SQLite, файл базы данных называется studios_films.db
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        /// <summary>
        /// Дополнительная настройка моделей (правила связей между таблицами).
        /// Здесь мы НАСТРАИВАЕМ связь "один ко многим" между студиями и фильмами.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настраиваем связь: одна студия (Studio) имеет много фильмов (Films)
            modelBuilder.Entity<Studio>()
                .HasMany(s => s.Films)           // У студии много фильмов
                .WithOne(f => f.Studio)           // У фильма одна студия
                .HasForeignKey(f => f.StudioId)   // Внешний ключ в таблице Films — StudioId
                .OnDelete(DeleteBehavior.Restrict); // ЗАПРЕЩАЕМ удалять студию, если у неё есть фильмы
        }
    }
}