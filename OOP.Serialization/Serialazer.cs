using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP.Serialization
{
    public static class Serialazer
    {
        public static void BinSer<T>(string file, T item)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream f = new FileStream(file + ".dat", FileMode.OpenOrCreate))
            {
                serializer.Serialize(f, item);
                Console.WriteLine($"{file + ".dat"} сериализован");
            }
        }

        public static void BinDes<T>(string file, ref T item)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream f = File.OpenRead(file + ".dat"))
            {
                item = (T)serializer.Deserialize(f);
                Console.WriteLine($"{file + ".dat"} десериализован");
            }
        }

        public static void XmlSer<T>(string file, T item)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream f = new FileStream(file + ".xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(f, item);
                Console.WriteLine($"{file + ".dat"} сериализован");
            }
        }
    }
}
