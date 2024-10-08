using ProjetoPastelaria.Data;
using ProjetoPastelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Repositorio
{
    public class TarefasRepositorio : ITarefasRepositorio
    {
        //fazendo a injeção de dependencia  mas esse bancocontext nao consigo acessar ele o criar  entao tem que extrair uma var 
        private readonly BancoContext _bancoContext;
        public TarefasRepositorio(BancoContext bancocontext)
        {
            _bancoContext = bancocontext;
        }

        public TarefasModel ListarPorId(int id)
        {
            return _bancoContext.Tarefas.FirstOrDefault(x=>x.IdTarefa == id);
        }
        public List<TarefasModel> BuscarTodos()
        {
            return _bancoContext.Tarefas.ToList();
        }
        public TarefasModel Adicionar(TarefasModel tarefas)
        {
            //gravar no banco de dados porem quem grava e o contexto intt temos que injetar o contexto
            //chamar qual tabela e adiciona o funcionario
            //inserindo no banco a adição de um novo funcionario
            _bancoContext.Tarefas.Add(tarefas);
            _bancoContext.SaveChanges();
            return tarefas;
        }

       public TarefasModel Atualizar(TarefasModel tarefas)
        {
            TarefasModel tarefasDB = ListarPorId(tarefas.IdTarefa);

            if (tarefasDB == null) throw new Exception("Houve Um erro na alteração da tarefa");

           
            tarefasDB.Descricao = tarefas.Descricao;
            tarefasDB.PrazoConclusao = tarefas.PrazoConclusao;
            //funcionarioDB.Endereco = funcionario.Endereco;


            _bancoContext.Tarefas.Update(tarefasDB);
            _bancoContext.SaveChanges();
            return tarefasDB;
        }

        public bool Apagar(int id)
        {
            TarefasModel tarefasDB = ListarPorId(id);

            if (tarefasDB == null) throw new Exception("Houve Um erro na deleção da tarefa !");

            _bancoContext.Tarefas.Remove(tarefasDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
