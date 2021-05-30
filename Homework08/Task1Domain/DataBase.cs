using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;


namespace Task1Domain
{
    public class DataBase
    {
        private string _dbFolderPath;
        private string _dbFilePath;
        private int _id;

        public DataBase()
        {
            _id = 0;
            _dbFolderPath = @"..\..\..\";
            _dbFilePath = _dbFolderPath + $"\\Dog.json";
            if (!Directory.Exists(_dbFolderPath))
            {
                Directory.CreateDirectory(_dbFolderPath);
            }
            if (!File.Exists(_dbFilePath))
            {
                File.Create(_dbFilePath).Close();
            }

            List<Dog> data = Read();
            if (data == null)
            {
                Write(new List<Dog>());
            }
            else if (data.Count > 0)
            {
                _id = data[data.Count - 1].Id;
            }
        }

        private List<Dog> Read()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(_dbFilePath))
                {
                    string content = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Dog>>(content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private void Write(List<Dog> dogs)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_dbFilePath))
                {
                    string jsonString = JsonConvert.SerializeObject(dogs);
                    streamWriter.WriteLine(jsonString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        public List<Dog> GetAllDogs()
        {
            return Read();
        }
        public Dog GetById(int id)
        {
            return Read().SingleOrDefault(x => x.Id == id);
        }
        private void ClearDb()
        {
            Write(new List<Dog>());
        }
        public int Insert(Dog entity)
        {
            List<Dog> data = Read();
            _id++;
            entity.Id = _id;
            data.Add(entity);
            Write(data);
            return entity.Id;
        }
    }
}
