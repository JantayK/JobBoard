﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HeadHunterПРОБНЫЙ.Enums
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
