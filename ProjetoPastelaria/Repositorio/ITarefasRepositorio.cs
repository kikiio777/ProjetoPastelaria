using ProjetoPastelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Repositorio
{
    public interface ITarefasRepositorio
    {

        TarefasModel ListarPorId(int id);
        //criar  crontrato pra listar os dados
        List<TarefasModel> BuscarTodos();
        //contrato de adicionar  de funcinario model recebe como parametro ele mesmo e retorna ele mesmo
        TarefasModel Adicionar(TarefasModel tarefas);

        TarefasModel Atualizar(TarefasModel tarefas);

        bool Apagar(int id);
    }
}
