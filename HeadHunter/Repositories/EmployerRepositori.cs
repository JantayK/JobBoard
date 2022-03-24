using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeadHunter.Models;

namespace HeadHunter.Repositories
{
    public class EmployerRepositori: IUserRepositori<Employer>
    {
        public void AddNewUser(Employer user)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.Employers.Add(user);
                dbContext.SaveChanges();
            }
        }

        public bool getSearchLoginUser(string login)
        {
            bool isSerch = false;
             using (ApplicationDbContext dbContext = new ApplicationDbContext())
             {
                 isSerch = dbContext.Users.Any(x => x.Login == login);
             }

             return isSerch;
        }
    }
}
