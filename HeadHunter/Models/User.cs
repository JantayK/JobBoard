using  HeadHunter.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeadHunter.Models
{
    /// <summary>
    /// Абстрактный класс User 
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
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public  string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string SurName { get; set; }

        /// <summary>
        /// Логин для входа 
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public  string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }
    }
}
