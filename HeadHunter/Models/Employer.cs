using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeadHunter.Models
{
    public class Employer : User
    {
        public Employer()
        {

        }

        public Employer(string companyname, string description, int fundyear, string address, string firstname, string surname, string login, string password, string email) : base(firstname, surname, login, password, email) 
        {
            CompanyName = companyname;
            Description = description;
            FoundationYear = fundyear;
            Address = address;
        }


        /// <summary>
        /// Наименование компании работодателя
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string CompanyName { get; set; }
        /// <summary>
        /// Описание работодателя
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Год основания
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public int FoundationYear { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Ссылка на вакансии
        /// </summary>
        public virtual ICollection<Vacancy> VacancyList { get; set; }
    }
}
