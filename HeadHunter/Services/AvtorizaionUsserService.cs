using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Repositories;
using HeadHunter.Utilits;

namespace HeadHunter.Services
{
    public class AvtorizaionUsserService
    {
        private AvtorizaionUsser _avtorizaion = new AvtorizaionUsser();


        public Result<bool> Avtorizaion(string login, string pass)
        {
            var errors = new StringBuilder();

            if (login == null || pass == null)
            {
                errors.Append("Все поля должны быть заполнины \n");
            }

            if (!_avtorizaion.AvtorizaionUssers(login, pass))
            {
                errors.Append("Пользователь не найден\n");
            }

            var errorMessage = errors.ToString();
            if (!string.IsNullOrEmpty(errorMessage))
                return new Result<bool> {IsSuccess = false, Message = errorMessage};



            return new Result<bool> {IsSuccess = true, Message = ""};
        }

        public Result<bool> AvtorizaionTupe(string login)
        {
            return new Result<bool> {IsSuccess = true, Message = _avtorizaion.GetUsserType(login).ToString()};
        }
    }
}