using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunter.Enums
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
