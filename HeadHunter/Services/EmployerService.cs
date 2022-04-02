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
        private IUserRepository<Employer> _userRepositori;

        public EmployerService()
        {
            _userRepositori = new EmployerRepository();
        }

        public Result<bool> RegisteredUser(Employer employer, string pass2)
        {
            var errors = new StringBuilder();

            
            if (_userRepositori.SearchLoginUser(employer.Login))
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
