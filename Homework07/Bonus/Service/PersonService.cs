using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bonus.Service
{
    public class PersonService
    {
        private string _appPath;
        private string _folderPath;
        private string _errorPath;
        private string _personPath;

        public PersonService()
        {
            _appPath = @"..\..\..\";
            _folderPath = _appPath + "Exercise";
            _personPath = _folderPath + @"\personInfo.txt";
            _errorPath = _folderPath + @"\error.txt";
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }

        public void Info(string info)
        {
            using (StreamWriter sw = new StreamWriter(_personPath, true))
            {

                sw.WriteLine($"{info}");
                
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
