using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Saving_System
{
    internal class BinarySerialization<T> : IData<T>
    {
        public void Save(T data, string filePath)
        {
            SerializeToFile(data, filePath);
        }

        public T Load(string filePath)
        {
            return DeserializeFromFile(filePath);
        }

        private void SerializeToFile(T data, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, data);
            }
        }

        private T DeserializeFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("There is no data in " + filePath);
                return default(T);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(fs);
            }
        }
    }
}
