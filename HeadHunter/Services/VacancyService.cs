using HeadHunter.Models;
using HeadHunter.Repositories;
using HeadHunter.Utilits;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunter.Services
{
    public class VacancyService
    {
        private VacanciesRepository _vacancyRepository;
        public VacancyService()
        {
             _vacancyRepository = new VacanciesRepository();
        }

        public Result<bool> RegisteredVacancy(Vacancy vacancy)
        {
            var errors = new StringBuilder();

            if (vacancy == null || (vacancy.Name == null && vacancy.Name.Trim() == "") ||
                (vacancy.Description == null && vacancy.Description.Trim() == "") ||
                (vacancy.KeySkills == null && vacancy.KeySkills.Trim() == "") ||
                (vacancy.Address == null && vacancy.Address.Trim() == "") ||
                (vacancy.Contact == null && vacancy.Contact.Trim() == ""))
            {
                errors.Append("Все поля должны быть заполнены! \n");
            }
            if(vacancy.Salary <= 0)
            {
                errors.Append("Неверно введен оклад");
            }

            var errorMessage = errors.ToString();
            if (!string.IsNullOrEmpty(errorMessage))
                return new Result<bool> { IsSuccess = false, Message = errorMessage };

            try
            {
                _vacancyRepository.AddNewVacancy(vacancy);
                return new Result<bool>
                {
                    IsSuccess = true,
                    Message = "",

                };
            }

            catch (Exception ex)
            {
                return new Result<bool>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }
    }
}
