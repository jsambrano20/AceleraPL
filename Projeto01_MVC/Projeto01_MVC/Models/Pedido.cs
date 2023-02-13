using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Projeto01_MVC.Models
{
    public class Pedido
    {
        [Display(Name = "Codigo do Cliente")]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}