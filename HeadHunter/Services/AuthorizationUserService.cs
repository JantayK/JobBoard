using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Repositories;
using HeadHunter.Utilits;

namespace HeadHunter.Services
{
    public class AuthorizationUserService
    {
        private AuthorizationUser _avtorizaion = new AuthorizationUser();


        public Result<bool> Authorization(string login, string pass)
        {
            var errors = new StringBuilder();

            if (login == null || pass == null)
            {
                errors.Append("Все поля должны быть заполнены! \n");
            }

            if (!_avtorizaion.AuthorizationUsers(login, pass))
            {
                errors.Append("Пользователь не найден\n");
            }

            var errorMessage = errors.ToString();
            if (!string.IsNullOrEmpty(errorMessage))
                return new Result<bool> {IsSuccess = false, Message = errorMessage};



            return new Result<bool> {IsSuccess = true, Message = ""};
        }

        public Result<bool> AuthorizationType(string login)
        {
            return new Result<bool>
            {
                IsSuccess = true, Message = _avtorizaion.GetUserType(login).ToString(),
                UserId = _avtorizaion.GetUserId(login)
            };
        }
    }
}