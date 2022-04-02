using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Models;
using HeadHunter.Repositories;
using HeadHunter.Utilits;

namespace HeadHunter.Services
{
    public class EmployeeService
    {
        private IUserRepository<Employee> _userRepositori;

        public EmployeeService()
        {
            _userRepositori = new EmployeesRepository();
        }


        public Result<bool> RegisteredUser(Employee employee, string pass2)
        {
            var errors = new StringBuilder();

            
            if (_userRepositori.SearchLoginUser(employee.Login))
            {
                errors.Append("Такой пользователь уже есть \n");
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
