using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Controllers.Helps
{
    public class MD5Create
    {
        public static string GetMD5Hash(string imput)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(imput);
                b = provider.ComputeHash(b);
                StringBuilder sb = new StringBuilder();
                foreach (var item in b)
                    sb.Append(item.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
