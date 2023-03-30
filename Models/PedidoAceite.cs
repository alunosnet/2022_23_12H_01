using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ServicosEPedidos_Mod_17E.Models
{
    public class PedidoAceite
    {
        [Key]
        public int IdPedAc { get; set; }

        [ForeignKey("IdPrest")]
        [Display(Name = "Prestador")]
        [Required(ErrorMessage = "Tem de indicar o prestador")]
        public int PrestadorId { get; set; }
        public Utilizador IdPrest { get; set; }


        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tem de indicar a data do Pedido")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPedAc { get; set; }

        [ForeignKey("IdPedido")]
        [Display(Name = "Pedido")]
        [Required(ErrorMessage = "Tem de indicar o prestador")]
        public int PedidoId { get; set; }
        public Pedido IdPedido { get; set; }

        ////////////////////////////////// valor default para data do pedido Aceite
        public PedidoAceite()
        {
            DataPedAc = DateTime.Now;
        }
    }
}