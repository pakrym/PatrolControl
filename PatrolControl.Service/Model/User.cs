using System;
using System.Runtime.Serialization;
using System.Text;

namespace PatrolControl.Service.Model
{
    [DataContract]
    [GenerateProvider]
    public class User : Entity
    {
        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String PasswordHash { get; set; }

        
        private String Password 
        {
            set { PasswordHash = Encript(value); }
        }

        [DataMember]
        public int Type { get; set; }

        private static String Encript(String value)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(value);

            var hash = x.ComputeHash(data);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public bool ValidatePasword(String pasword)
        {
            return PasswordHash.Equals(Encript(pasword));
        }
    }
}