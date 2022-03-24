using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunter.Repositories
{
    public interface IUserRepositori<T>
    {
        void AddNewUser(T user);
        bool getSearchLoginUser(string login);
    }
}
