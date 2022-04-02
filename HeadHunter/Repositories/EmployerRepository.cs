using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeadHunter.Models;

namespace HeadHunter.Repositories
{
    public class EmployerRepository: IUserRepository<Employer>
    {
        public void AddNewUser(Employer user)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.Employers.Add(user);
                dbContext.SaveChanges();
            }
        }

        public bool SearchLoginUser(string login)
        {
            bool isFound = false;
             using (ApplicationDbContext dbContext = new ApplicationDbContext())
             {
                 isFound = dbContext.Users.Any(x => x.Login == login);
             }

             return isFound;
        }
    }
}
