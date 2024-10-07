using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Models
{
    public class FuncionarioModel
    {
        //id do usuario  sendo gerando sequencialmente 
        public int Id { get; set; }


       [Required(ErrorMessage ="Digite o Nome !")]
        public string NomeCompleto { get; set; }

       [Required(ErrorMessage = "digite a Data de nascimento !")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "digite o telefone !")]
        public string TelFixo  { get; set; }


        [Required(ErrorMessage = "Digite o celular !")]
        [Phone(ErrorMessage ="celular nao é valido !")]
        public string Celular { get; set; }


       [Required(ErrorMessage = "digite o email !")]
       [EmailAddress(ErrorMessage ="digite um email valido !")]
        public string Email { get; set; }


       [Required(ErrorMessage = "digite um endereço!")]
        public string Endereco { get; set; }


        public string Perfil { get; set; }


        [Required(ErrorMessage = "Digite uma senha !")]
        public string Senha { get; set; }

        public virtual ICollection<TarefasModel> Tarefas { get; set; }
    }
}
