    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServicosEPedidos_Mod_17E.Models
{
    public class Pedido
    {
        [Key]
        public int IdPed { get; set; }

        [ForeignKey("IdClie")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Tem de indicar o cliente")]
        public int ClienteId { get; set; }
        public Utilizador IdClie { get; set; }

        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tem de indicar a data do Pedido")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPed { get; set; }

        [Required(ErrorMessage = "Tem de indicar o tipo de serviço")]
        [StringLength(20)]
        [UIHint("Indique o tipo de serviço")]
        [Display(Name = "Tipo de Serviço")]
        public string Tipo { get; set; }

        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Indique uma descricao")]
        [StringLength(100)]
        [UIHint("Indique uma descricao")]
        public string Descricao { get; set; }

        public bool Estado { get; set; }


        ////////////////////////////////// valor default para data do pedido
        public Pedido()
        {
            DataPed = DateTime.Now;
            Estado = false;
            
        }

    }
}