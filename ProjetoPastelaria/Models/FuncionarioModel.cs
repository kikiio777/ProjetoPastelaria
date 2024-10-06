using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Models
{
    public class FuncionarioModel
    {
        //id do usuario  sendo gerando sequencialmente 
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNasc { get; set; }
        public string TelFixo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Perfil { get; set; }
        public string Senha { get; set; }
    }
}
