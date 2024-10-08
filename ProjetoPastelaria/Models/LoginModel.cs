using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPastelaria.Models
{
    public class LoginModel
    {
        [Required (ErrorMessage = "Informe o login")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }
    }
}
