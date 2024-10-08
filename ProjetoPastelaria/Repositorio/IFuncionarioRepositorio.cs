using ProjetoPastelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Repositorio
{
    public interface IFuncionarioRepositorio
    {
        FuncionarioModel BuscarPLogin(string login);
        FuncionarioModel ListarPorId(int id);
        //criar  crontrato pra listar os dados
        List<FuncionarioModel> BuscarTodos();
        //contrato de adicionar  de funcinario model recebe como parametro ele mesmo e retorna ele mesmo
        FuncionarioModel Adicionar(FuncionarioModel funcionario);

        FuncionarioModel Atualizar(FuncionarioModel funcionario);

        bool Apagar(int id);
    }
}
