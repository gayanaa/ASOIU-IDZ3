using Microsoft.EntityFrameworkCore;

namespace IDZ3.Models
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Таблица киностудий
        /// </summary>
        public DbSet<Studio> Studios { get; set; }

        /// <summary>
        /// Таблица фильмов
        /// </summary>
        public DbSet<Film> Films { get; set; }

        private static readonly string DbPath = "studios_films.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи "один ко многим"
            modelBuilder.Entity<Studio>()
                .HasMany(s => s.Films)
                .WithOne(f => f.Studio)
                .HasForeignKey(f => f.StudioId)
                .OnDelete(DeleteBehavior.Restrict); // Запрет удаления студии с фильмами
        }
    }
}