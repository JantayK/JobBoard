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
        public User()
        {

        }

        public User(string firstname, string surname, string login, string password, string email)
        {
            FirstName = firstname;
            SurName = surname;
            Login = login;
            Password = password;
            Email = email;
        }
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

        public string Discriminator { get; set; }
    }
}
