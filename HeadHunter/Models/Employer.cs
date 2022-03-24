using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunter.Models
{
    public class Employer : User
    {
        public Employer(string companyname, string description, int fundyear, string address  )
        {
            CompanyName = companyname;
            Description = description;
            FoundationYear = fundyear;
            Address = address;
        }


        /// <summary>
        /// Наименование компании работодателя
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Описание работодателя
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Год основания
        /// </summary>
        public int FoundationYear { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
    }
}
