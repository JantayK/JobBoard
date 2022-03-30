using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunter.Utilits
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public  int UserId { get; set; }
    }
}
