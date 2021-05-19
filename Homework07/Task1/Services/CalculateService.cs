using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task1.Services
{
    public class CalculateService
    {
        private string _appPath;
        private string _folderPath;
        private string _errorPath;
        private string _calculatePath;

        public CalculateService()
        {
            _appPath = @"..\..\..\";
            _folderPath = _appPath + "Exercise";
            _calculatePath = _folderPath + @"\calculate.txt";
            _errorPath = _folderPath + @"\error.txt";

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }
       
        
        public void Calculate(string sum)
        {
            using(StreamWriter sw = new StreamWriter(_calculatePath, true)){

                sw.WriteLine($"SUM: {sum}");
                sw.WriteLine("===============");
            }
        }

        public void Error(string error, string message)
        {
            using (StreamWriter sw = new StreamWriter(_errorPath, true))
            {
                sw.WriteLine($"[Error]: {error}");
                sw.WriteLine($"Message: {message}");
                sw.WriteLine($"Time: {DateTime.Now}");
                sw.WriteLine("=====================");
            }
        }



    }
}
