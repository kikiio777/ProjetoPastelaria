using ProjetoPastelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Helpers
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(FuncionarioModel funcionario);
        void RemoverSessaoDoUsuario();

        FuncionarioModel BuscarSessaoDoUsuario();
    }
}
