using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Domain.Classes
{
    public class Circle : Shape
    {
        
        public double Radius { get; set; }
        public Circle(int Id,double radius) : base(Id)
        {
            Radius = radius;
        }
        public override double GetArea()
        {
            if (Radius <= 0)
            {
                throw new ArgumentException("Radius can not be a negative number or zero");
            }
            return  Math.PI * (Radius * Radius);
        }

        public override double GetPerimeter()
        {
            if (Radius <= 0)
            {
                throw new ArgumentException("Radius can not be a negative number or zero");
            }
            return 2 * Math.PI * Radius;
        }

       
    }
}
