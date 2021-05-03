using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Domain.Classes
{
    public abstract class Shape
    {
        public int ID { get; set; }

        public  Shape(int Id)
        {
            ID = Id;
        }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
