
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeadHunter.Enums;
using HeadHunter.Models;

namespace HeadHunter.Repositories
{
    public class VacanciesRepository
    {
        public void AddNewVacancy(Vacancy vacancy)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.Vacancies.Add(vacancy);
                dbContext.SaveChanges();
            }
        }

        public List<Vacancy> GetVacancyOpen()
        {
            List<Vacancy> vacancies = new List<Vacancy>();
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                vacancies = dbContext.Vacancies.Where(x => x.Type == VacancyType.Open).ToList();
            }

            return vacancies;
        }
        public List<Vacancy> GetVacancy(int employer)
        {
            List<Vacancy> vacancies = new List<Vacancy>();
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                vacancies = dbContext.Vacancies.Where(x => x.EmpId == employer).ToList();
            }

            return vacancies;
        }
        public void ChangeVacancyType(int vacancyId, VacancyType option)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var vacancy = dbContext.Vacancies.FirstOrDefault(x => x.Id == vacancyId && x.Type != option);
                if(vacancy != null)
                {
                    vacancy.Type = option;
                    dbContext.SaveChanges();
                    Console.WriteLine("Тип вакансии успешно изменен на " + option);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вакансия не найдена");
                    Console.ResetColor();
                }
            }
        }


    }
}
