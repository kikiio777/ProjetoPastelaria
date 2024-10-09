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
            //cria uma instancia do algoritmo sha para  gerar o hash
            var hash = SHA1.Create();

            var encoding = new ASCIIEncoding();
            //se digitar 1234 ele pega todos os bytes e transforma num array de bytes


            //aqui ja esta convertendo a string em  array d bytes
            var array = encoding.GetBytes(valor);

            //gerando o hash  da array d bytes
            array = hash.ComputeHash(array);


            var strHexa = new StringBuilder();//criando um stringbuilder pra construir a string hexadecimal do  hash


            //convertendo cada item q no caso e byte do array  gerado  em hexadecimal
            foreach (var item in array)
            {
                // Adiciona a representação hexadecimal de cada byte ao StringBuilder ee jogando no bd
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }
    }
}
