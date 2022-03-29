using System;
using System.Collections.Generic;
using System.Text;
using HeadHunter.Models;
using HeadHunter.Utilits;

namespace HeadHunter.Services
{
    public interface IUserService
    {
        Result<bool> RegistredUser<T>( T user, string pass2) 
            where T : User;
    }
}
