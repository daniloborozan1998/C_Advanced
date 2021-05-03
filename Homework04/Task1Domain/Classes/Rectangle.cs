using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Domain.Classes
{
    public class Rectangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }

        public Rectangle(int Id,double sideA,double sideB) : base(Id)
        {
            SideA = sideA;
            SideB = sideB;
        }
        public override double GetArea()
        {
            if (SideA <= 0 || SideB <= 0)
            {
                throw new ArgumentException("Length and  Width can not be a negative number or zero");
            }
            return SideA * SideB;
            
        }

        public override double GetPerimeter()
        {
            if (SideA  <= 0 || SideB <= 0)
            {
                throw new ArgumentException("Length and  Width can not be a negative number or zero");
            }
            return 2 * (SideA + SideB);
        }

        
    }
}
