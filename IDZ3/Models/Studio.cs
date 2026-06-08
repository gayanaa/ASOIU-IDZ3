using System.Collections.Generic;

namespace IDZ3.Models
{
    /// <summary>
    /// Класс, представляющий киностудию (справочная таблица)
    /// </summary>
    public class Studio
    {
        /// <summary>
        /// Уникальный идентификатор студии (первичный ключ)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название киностудии
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Навигационное свойство: фильмы этой студии
        /// </summary>
        public ICollection<Film> Films { get; set; } = new List<Film>();
    }
}