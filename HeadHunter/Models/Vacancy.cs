
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using HeadHunter.Enums;

namespace HeadHunter.Models
{
    public class Vacancy : IEntity<int>
    {
        public Vacancy()
        {

        }

        public Vacancy(string name, string description, string keyskills, string address, decimal salary, string contact)
        {
            Name = name;
            Description = description;
            KeySkills = keyskills;
            Address = address;
            Salary = salary;
            Contact = contact;
        }
        /// <summary>
        /// Идентификатор вакансии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор работодателя
        /// </summary>
        [ForeignKey("Employer")]
        public int? EmpId { get; set; }

        /// <summary>
        /// Название вакансии
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Тип вакансии
        /// </summary>
        public VacancyType Type { get; set; }

        /// <summary>
        /// Описание вакансии
        /// </summary>
        [Required]
        [StringLength(70, MinimumLength = 1)]
        public string Description { get; set; }

        /// <summary>
        /// Ключевые умения
        /// </summary>
        [Required]
        [StringLength(70, MinimumLength = 1)]
        public string KeySkills { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Address { get; set; }

        /// <summary>
        /// Опыт работы
        /// </summary>
        public ExperienceType Experience { get; set; }

        /// <summary>
        /// Тип занятости
        /// </summary>
        public EmploymentType? Employment { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        [Required]
        public decimal Salary { get; set; }

        /// <summary>
        /// Дата публикации вакансии
        /// </summary>
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// Контакты
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Contact { get; set; }

        /// <summary>
        /// Имеется тестовое задание
        /// </summary>
        public HasTest Hastest { get; set; }


        /// <summary>
        /// Работодатель
        /// </summary>
        public virtual Employer Employer { get; set; }

        /// <summary>
        /// Список подавшихся на вакансию работников
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Номер вакансии: " + Id);
            Console.WriteLine("Название вакансии: " + Name);
            Console.WriteLine("Описание вакансии: " + Description);
            Console.WriteLine("Тип вакансии: " + Type);
            Console.WriteLine("Ключевые умения: " + KeySkills);
            Console.WriteLine("Адрес: " + Address);
            Console.WriteLine("Необходимый опыт работы: " + Experience);
            Console.WriteLine("Оклад: " + Salary);
            Console.WriteLine("Дата публикации вакансии: " + PublishedAt);
            Console.WriteLine("Контакты: " + Contact);
            Console.WriteLine("Имеется ли тестовое задание: " + Hastest);
            Console.WriteLine("--------------------------------");
        }
    }
}
