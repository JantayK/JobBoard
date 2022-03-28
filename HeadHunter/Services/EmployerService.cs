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

        public Result<bool> RegistredUser(Employer employer, string pass2)
        {
            var errors = new StringBuilder();

            if (employer == null || (employer.Login == null && employer.Login.Trim() =="") || 
                (employer.Password == null && employer.Password.Trim() =="")||
                (employer.FirstName == null && employer.FirstName.Trim() == "")||
                (employer.SurName == null && employer.SurName.Trim() == "")||
                (employer.Email == null && employer.Email.Trim() == "")||
                (employer.CompanyName == null && employer.CompanyName.Trim() == "")||
                (employer.FoundationYear == null&& employer.FoundationYear == 0 ))
            {
                errors.Append("Все поля должны быть заполнены! \n");
            }
            if (_userRepositori.getSearchLoginUser(employer.Login))
            {
                errors.Append("Такой пользователь уже есть \n");
            }

            if (employer.Password == pass2)
            {
                errors.Append("Пороли не совпадают \n");
            }
            if (employer.Password.Length >= 6)
            {
                errors.Append("Пороли меньше 6 символов \n");
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
