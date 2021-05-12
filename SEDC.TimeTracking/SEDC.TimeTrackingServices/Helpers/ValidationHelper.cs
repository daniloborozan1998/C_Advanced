using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.TimeTrackingServices.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidationUsername(string username)
        {
            if (username.Length < 5 && username.Length > 20)
            {
                return false;
            }

            return true;
        }

        public static bool ValidationPassword(string password)
        {
            if (password.Length < 6 && password.Length > 20)
            {
                return false;
            }
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }
            


            return true;
        }


        public static bool ValidationFirstName(string fname)
        {
            if (fname.Any(char.IsDigit))
            {
                return false;
            }
            if (fname.Length < 2 && fname.Length > 20)
            {
                return false;
            }

            return true;
        }
        public static bool ValidationLastName(string lname)
        {
            if (lname.Any(char.IsDigit))
            {
                return false;
            }

            if (lname.Length < 2 && lname.Length > 20)
            {
                return false;
            }

            return true;
        }


        public static bool ValidationAge(int age)
        {
            if (age < 18 && age > 120)
            {
                return false;
            }

            return true;
        }
    }
}
