using ProjetoPastelaria.Data;
using ProjetoPastelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        //fazendo a injeção de dependencia  mas esse bancocontext nao consigo acessar ele o criar  entao tem que extrair uma var 
        private readonly BancoContext _bancoContext;
        public FuncionarioRepositorio(BancoContext bancocontext)
        {
            _bancoContext = bancocontext;
        }

        public List<FuncionarioModel> BuscarTodos()
        {
            return _bancoContext.Funcionarios.ToList();
        }
        public FuncionarioModel Adicionar(FuncionarioModel funcionario)
        {
            //gravar no banco de dados porem quem grava e o contexto intt temos que injetar o contexto
            //chamar qual tabela e adiciona o funcionario
            //inserindo no banco a adição de um novo funcionario
            _bancoContext.Funcionarios.Add(funcionario);
            _bancoContext.SaveChanges();
            return funcionario;
        }
    }
}
