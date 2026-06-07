using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace IDZ3.Models
{
    /// <summary>
    /// Класс, представляющий киностудию.
    /// Каждый объект Studio = одна запись в таблице Studios.
    /// Это СПРАВОЧНИК (master table).
    /// </summary>
    public class Studio
    {
        /// <summary>
        /// Уникальный идентификатор студии.
        /// Это первичный ключ (Primary Key) в базе данных.
        /// EF Core сам поймёт, что Id - это ключ.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название киностудии. Например, "Warner Bros", "Universal".
        /// Это поле обязательно для заполнения (NOT NULL в БД).
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Навигационное свойство - список фильмов, которые сняла эта студия.
        /// EF Core использует это для связи "один ко многим".
        /// </summary>
        public List<Film> Films { get; set; } = new List<Film>();
    }
}