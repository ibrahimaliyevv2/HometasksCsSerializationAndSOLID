using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationTry
{
    class Program
    {
        static string _path = "/Users/ibrahimaliyevv/Desktop/SerializationTryFiles/";
        static void Main(string[] args)
        {
            //User user1 = new User
            //{
            //    Name = "Asif",
            //    Surname = "Allazov",
            //    Age = 32
            //};

            //SerializeDat(user1);

            User desUser = DeserializeDat();
            Console.WriteLine($"Name: {desUser.Name}, Surname: {desUser.Surname}, Age: {desUser.Age}");
        }

        //using olmadan serialize
        static void SerializeDat(User user)
        {
            FileStream fileStream = new FileStream(_path + "user1.dat", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, user);
            fileStream.Close();
        }

        //using olmadiqda IDisposable obyektleri garbagecollector baglayir
        //Bu halda stream-i close etmek mutleqdir!

        //using olmadan deserialize
        static User DeserializeDat()
        {
            FileStream fileStream = new FileStream(_path + "user1.dat", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            User data = (User)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return data;
        }

        //using ile serialize
        static void UseSerializeDat(User user)
        {
            using (FileStream fileStream = new FileStream(_path + "user1.dat", FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, user);
            }
 
        }

        //using ile etdikde IDisponsable obyektleri garbagecollector yox, ozumuz baglayiriq
        //Bu halda stream-i close etmeye ehtiyac yoxdur!

        //using ile deserialize
        static User UseDeserializeDat()
        {
            using (FileStream fileStream = new FileStream(_path + "user1.dat", FileMode.Open)) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                User data = (User)binaryFormatter.Deserialize(fileStream);
                return data;
            }
        }

        //using parameter olaraq fileStream qebul edir, amma onu ozunu ele parameter hissede yaradiriq!
        //Eks halda islemir!

        //IDisposable - sen bu obyekti ozun dispose ede bilersen!
        //Normalda GarbageCollector, amma using-le sen
        //Stream IDisposable interfeysinden implement edir


        //Sual: using keyword-u hansi isleri gorur?
        // 1: namespace-leri cagirmaq ucun, basqa proyektdeki class-in field, property ve metodlarindan istifade etmek ucun onun namespace-ini cagiririq
        // 2: IDisposable obyektleri isi bitdikde GarbageCollectorun yerine(o yox ozumuzun) avtomatik baglamaq ucun
    }
}
