using HeadHunter.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeadHunter.Models
{
    /// <summary>
    /// Класс Работника
    /// </summary>
    public class Employee : User
    {
        public Employee()
        {

        }

        public Employee(string employeeinfo, string firstname, string surname, string login, string password, string email) : base(firstname, surname, login, password, email)
        {
            EmployeeInfo = employeeinfo;
        }

        /// <summary>
        /// Стаж работы
        /// </summary>
        [Required]
        public ExperienceType Experience { get; set; }
        /// <summary>
        /// Тип образования
        /// </summary>
        [Required]
        public EducationType Education { get; set; }
        /// <summary>
        /// Описание, информация о работнике
        /// </summary>
        [Required]
        public string EmployeeInfo { get; set; }

    }
}
