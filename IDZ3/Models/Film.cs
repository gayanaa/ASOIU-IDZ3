namespace IDZ3.Models
{
    /// <summary>
    /// Класс, представляющий фильм.
    /// Каждый объект Film = одна запись в таблице Films.
    /// Это ОСНОВНАЯ ТАБЛИЦА (detail table).
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Уникальный идентификатор фильма. Первичный ключ.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название фильма. Например, "Inception", "The Dark Knight".
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Бюджет фильма в МИЛЛИОНАХ долларов.
        /// Тип decimal выбран, потому что бюджет может быть дробным (например, 150.5 млн)
        /// </summary>
        public decimal BudgetMln { get; set; }

        /// <summary>
        /// ВНЕШНИЙ КЛЮЧ (Foreign Key).
        /// Хранит Id студии, которая сняла этот фильм.
        /// </summary>
        public int StudioId { get; set; }

        /// <summary>
        /// НАВИГАЦИОННОЕ СВОЙСТВО.
        /// Ссылка на объект Studio, которому принадлежит фильм.
        /// Знак ? означает, что значение может быть временно пустым (null).
        /// </summary>
        public virtual Studio? Studio { get; set; }
    }
}