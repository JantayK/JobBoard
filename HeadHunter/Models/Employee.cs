using HeadHunter.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeadHunter.Models
{
    /// <summary>
    /// Работник
    /// </summary>
    public class Employee : User
    {
        public Employee(string employeeinfo)
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
