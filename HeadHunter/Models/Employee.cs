using HeadHunter.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunter.Models
{
    /// <summary>
    /// Работник
    /// </summary>
    public class Employee : User
    {
        /// <summary>
        /// Стаж работы
        /// </summary>
        public ExperienceType Experience { get; set; }
        /// <summary>
        /// Тип образования
        /// </summary>
        public EducationType Education { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

    }
}
