using System;
using System.Collections.Generic;
using System.Text;
using Task1.Services;

namespace Task1.Exceptions
{
    public class InvalidInputException : Exception
    {
        private CalculateService _calculateService;

        public InvalidInputException() : base($"Invalid input")
        {
            _calculateService = new CalculateService();
           
        }
    }
}
