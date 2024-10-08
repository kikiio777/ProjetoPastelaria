using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPastelaria.Models
{
    public class TarefasModel
    {
        [Key]
        public int IdTarefa { get; set; }

        [Required(ErrorMessage = "Selecione um Funcionário!")]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "Digite a Descrição da Tarefa")]
        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Informe o Prazo para a Tarefa")]
        public DateTime? PrazoConclusao { get; set; }

        public int IdCriadorTarefa { get; set; }

        // Essa propriedade deve ser apenas para a lista de seleção
        [NotMapped]
        public List<SelectListItem> Funcionarios { get; set; } // Mantenha esta como List<SelectListItem>
    }
}
