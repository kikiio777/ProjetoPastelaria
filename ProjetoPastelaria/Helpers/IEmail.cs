using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Helpers
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}
