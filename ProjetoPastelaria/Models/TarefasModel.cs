using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Models
{
    public class TarefasModel
    {
        public int TarefaId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataVencimento { get; set; }
        //chave estrangeira do func
        public int Id { get; set; }
        //navegação para o funcionario
        public virtual FuncionarioModel Funcionario { get; set; }
    }
}
