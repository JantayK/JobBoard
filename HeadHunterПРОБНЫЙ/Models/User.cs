using HeadHunterПРОБНЫЙ.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunterПРОБНЫЙ.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class User : IEntity<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        string Password { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }
    }
}
