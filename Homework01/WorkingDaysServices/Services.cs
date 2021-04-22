using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingDaysServices
{
    public class Services
    {
        public void GetData(int year, int month, int days)
        {
            DateTime start = new DateTime(1999, 1, 1);
            DateTime end = DateTime.Today;
            
            
            if (days >= 1 && days<=31)
            {
                if (month>=1 && month<=12)
                {
                    DateTime data = new DateTime(year, month, days);
                    if (data >= start && data <= end)
                    {
                        if ((data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 1 && data.Month == 1) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 7 && data.Month == 1) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 20 && data.Month == 4) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 1 && data.Month == 5) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 25 && data.Month == 5) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 3 && data.Month == 8) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 8 && data.Month == 9) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 12 && data.Month == 10) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 23 && data.Month == 10) || (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday && data.Day == 8 && data.Month == 12))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("==================");
                            Console.WriteLine("Non-working day. It is a holiday and weekned");
                        }
                        else if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("==================");
                            Console.WriteLine("Non-working day. It's a weekend.");
                        }else if (data.Day == 1 && data.Month == 1 || data.Day == 7 && data.Month == 1 || data.Day == 20 && data.Month == 4 || data.Day == 1 && data.Month == 5 || data.Day == 25 && data.Month == 5 || data.Day == 3 && data.Month == 8 || data.Day == 8 && data.Month == 9 || data.Day == 12 && data.Month == 10 || data.Day == 23 && data.Month == 10 || data.Day == 8 && data.Month == 12)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("==================");
                            Console.WriteLine("Non-working day. It is a holiday.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("==================");
                            Console.WriteLine("Working day.");
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong year");
                    }
                }
                else
                {
                    throw new Exception("Wrong month");
                }
            }
            else
            {
                throw new Exception("Wrong days");
            }
            Console.ResetColor();
        }
    }
}
