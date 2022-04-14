using System;
namespace SerializationTry
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
    }
}
