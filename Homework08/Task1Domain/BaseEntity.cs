﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string GetInfo();
    }
}
