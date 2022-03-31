
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
    
    }
}
