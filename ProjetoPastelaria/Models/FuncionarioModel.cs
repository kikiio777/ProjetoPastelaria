using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjetoPastelaria.Enum;
using ProjetoPastelaria.Helpers;

namespace ProjetoPastelaria.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a Data de Nascimento!")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Digite o Telefone!")]
        public string TelFixo { get; set; }

        [Required(ErrorMessage = "Digite o Celular!")]
        [Phone(ErrorMessage = "Celular não é válido!")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite o Email!")]
        [EmailAddress(ErrorMessage = "Digite um Email válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite um Endereço!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Escolha um perfil !")]
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Digite uma Senha!")]
        public string Senha { get; set; }

        // Relaçãoo funcionario tera  uma coleçao de tarefas
        public virtual ICollection<TarefasModel> Tarefas { get; set; } = new List<TarefasModel>();

        //metodo pra validar senha  se a Senha que foi criada do usuario for igual a digitada para o acesso return true
        public  bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
    }
}
