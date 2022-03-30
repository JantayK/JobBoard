
using System;
using System.Collections.Generic;
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

        //public Vacancy(string name, string description, string keyskills, string address, decimal salary, bool archived, string contact, bool hastest)
        //{
        //    Name = name;
        //    Description = description;
        //    KeySkills = keyskills;
        //    Address = address;
        //    Salary = salary;
        //    Archived = archived;
        //    HasTest = hastest;
        //}
        /// <summary>
        /// Идентификатор вакансии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор работодателя
        /// </summary>
        public long EmployerId { get; set; }

        /// <summary>
        /// Название вакансии
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип вакансии
        /// </summary>
        public VacancyType Type { get; set; }

        /// <summary>
        /// Описание вакансии
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ключевые умения
        /// </summary>
        public string KeySkills { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
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
        public decimal Salary { get; set; }

        /// <summary>
        /// Вакансия архивирована или нет
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// Дата публикации вакансии
        /// </summary>
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// Контакты
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Имеется тестовое задание
        /// </summary>
        public bool HasTest { get; set; }


        /// <summary>
        /// Работодатель
        /// </summary>
        public virtual Employer Employer { get; set; }

        /// <summary>
        /// Список подавшихся на вакансию работников
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
