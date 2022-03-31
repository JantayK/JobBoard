using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunter.Repositories
{
    public interface IUserRepository<T>
    {
        void AddNewUser(T user);
        bool SearchLoginUser(string login);
    }
}
