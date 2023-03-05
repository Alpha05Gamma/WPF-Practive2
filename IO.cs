using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2
{
    static class IO
    {
        static string path = Directory.GetCurrentDirectory()+"/Notes/Notes.json";
        public static void Serialize<T>(T data) ///дженерик сериализация
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        public static T Deserialize<T>() /// дженерик десериализация
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                T data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
            else
            {
                File.Create(path);
                throw new Exception();
            }
        }
    }
}
