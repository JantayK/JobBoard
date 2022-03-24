using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Models;
using HeadHunter.Repositories;
using HeadHunter.Utilits;

namespace HeadHunter.Services
{
    public class EmployerService
    {
        private IUserRepositori<Employer> _userRepositori;

        public EmployerService()
        {
            _userRepositori = new EmployerRepositori();
        }

        public Result<bool> RegistredUser(Employer employer)
        {
            var errors = new StringBuilder();

            if (employer == null || (employer.Login == null && employer.Login.Trim() =="") || 
                (employer.Password == null && employer.Password.Trim() ==""))
            {
                errors.Append("Все поля должны быть заполнины \n");
            }
            if (_userRepositori.getSearchLoginUser(employer.Login))
            {
                errors.Append("Такой пользователь уже есть \n");
            }
            var errorMessage = errors.ToString();
            if (!string.IsNullOrEmpty(errorMessage))
                return new Result<bool> { IsSuccess = false, Message = errorMessage };

            try
            {


                _userRepositori.AddNewUser(employer);
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
