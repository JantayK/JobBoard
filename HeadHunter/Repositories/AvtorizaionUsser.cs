﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeadHunter.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace HeadHunter.Repositories
{
    public class AvtorizaionUsser
    {

        public bool AvtorizaionUssers(string login, string pass)
        {
            bool isValid = false;
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            { 
                isValid = dbContext.Users.Any(x => x.Login == login && x.Password == pass );
            }

            return isValid;
        }
    }
}