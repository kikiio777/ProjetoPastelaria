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

        public FuncionarioModel ListarPorId(int id)
        {
            return _bancoContext.Funcionarios.FirstOrDefault(x=>x.Id == id);
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

       public FuncionarioModel Atualizar(FuncionarioModel funcionario)
        {
            FuncionarioModel funcionarioDB = ListarPorId(funcionario.Id);

            if (funcionarioDB == null) throw new Exception("Houve Um erro na alteração do funcionario");

            funcionarioDB.NomeCompleto = funcionario.NomeCompleto;
            funcionarioDB.DataNasc = funcionario.DataNasc;
            funcionarioDB.TelFixo = funcionario.TelFixo;
            funcionarioDB.Celular = funcionario.Celular;
            funcionarioDB.Email = funcionario.Email;
            funcionarioDB.Endereco = funcionario.Endereco;
            funcionarioDB.Perfil = funcionario.Perfil;
            //funcionarioDB.Endereco = funcionario.Endereco;


            _bancoContext.Funcionarios.Update(funcionarioDB);
            _bancoContext.SaveChanges();
            return funcionarioDB;
        }

        public bool Apagar(int id)
        {
            FuncionarioModel funcionarioDB = ListarPorId(id);

            if (funcionarioDB == null) throw new Exception("Houve Um erro na deleção do funcionario");

            _bancoContext.Funcionarios.Remove(funcionarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
