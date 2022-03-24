using  HeadHunter.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunter.Models
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
        public  string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Логин для входа 
        /// </summary>
        public  string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        string Password { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }
    }
}
