using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Helpers
{
    public static class Criptografia
    {
        //esse this vira uma extensao da string 
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            //se digitar 1234 ele pega todos os bytes e transforma num array de bytes
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }
    }
}
