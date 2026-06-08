namespace IDZ3.Models
{
    /// <summary>
    /// Класс, представляющий фильм (основная таблица)
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Уникальный идентификатор фильма (первичный ключ)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название фильма
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Бюджет фильма в миллионах долларов
        /// </summary>
        public decimal BudgetMln { get; set; }

        /// <summary>
        /// Внешний ключ: идентификатор киностудии
        /// </summary>
        public int StudioId { get; set; }

        /// <summary>
        /// Навигационное свойство: киностудия
        /// </summary>
        public virtual Studio? Studio { get; set; }
    }
}