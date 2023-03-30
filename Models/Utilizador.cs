using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServicosEPedidos_Mod_17E.Models
{
    public class Utilizador
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Indique um nome de utilizador")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Indique um email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Indique uma morada")]
        public string Morada { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Indique o perfil do utilizador")]
        public int Perfil { get; set; }

        //  dropdown perfil
        public IEnumerable<System.Web.Mvc.SelectListItem> Perfis { get; set; }
    }
}