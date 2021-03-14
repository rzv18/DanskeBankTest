using System;
using System.IO;
using Data.Models;
using Data.Repositories.Interfaces;
using Newtonsoft.Json;

namespace Data.Repositories
{
    public class JsonRepository<T>: IRepository<T>
    {
        private readonly string _filePath;

        public JsonRepository()
        {
            _filePath = AppDomain.CurrentDomain.BaseDirectory;
            if (typeof(T) == typeof(LoanContract))
                _filePath += @"/Resources/loanSettings.json";
            else
                _filePath += @"/Resources/feeSettings.json";
        }


        public T GetFirst()
        {
            return Read();
        }

        public T Read()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(_filePath));
        }
        public void Write(T model)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(model));
        }

    }
}
