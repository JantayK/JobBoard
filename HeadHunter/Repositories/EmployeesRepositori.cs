using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Models;

namespace HeadHunter.Repositories
{
    public class EmployeesRepositori :IUserRepositori<Employee>
    {
        public void AddNewUser(Employee user)
        {
            throw new NotImplementedException();
        }

        public bool getSearchLoginUser(string login)
        {
            throw new NotImplementedException();
        }
    }
}
