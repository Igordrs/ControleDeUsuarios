using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class UsuarioConsultaViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}