using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Models;
using System.Linq;

namespace HeadHunter.Repositories
{
    public class EmployeesRepositori :IUserRepositori<Employee>
    {
        public void AddNewUser(Employee user)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.Employees.Add(user);
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
