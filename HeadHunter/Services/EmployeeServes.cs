using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Models;
using HeadHunter.Repositories;
using HeadHunter.Utilits;

namespace HeadHunter.Services
{
    public class EmployeeServes
    {
        private IUserRepositori<Employee> _userRepositori;

        public EmployeeServes()
        {
            _userRepositori = new EmployeesRepositori();
        }


        public Result<bool> RegistredUser(Employee employee, string pass2)
        {
            var errors = new StringBuilder();

            if (employee == null || (employee.Login == null && employee.Login.Trim() == "") ||
                (employee.Password == null && employee.Password.Trim() == "") ||
                (employee.FirstName == null && employee.FirstName.Trim() == "") ||
                (employee.SurName == null && employee.SurName.Trim() == "") ||
                (employee.Email == null && employee.Email.Trim() == ""))
            {
                errors.Append("Все поля должны быть заполнины \n");
            }
            if (_userRepositori.getSearchLoginUser(employee.Login))
            {
                errors.Append("Такой пользователь уже есть \n");
            }

            if (employee.Password == pass2)
            {
                errors.Append("Пороли не совпадают \n");
            }
            if (employee.Password.Length >= 6)
            {
                errors.Append("Пороли меньше 6 символов \n");
            }

            var errorMessage = errors.ToString();
            if (!string.IsNullOrEmpty(errorMessage))
                return new Result<bool> { IsSuccess = false, Message = errorMessage };

            try
            {


                _userRepositori.AddNewUser(employee);
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
