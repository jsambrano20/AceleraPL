using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vendedor.Models
{
    public class HistPedido
    {
        public int CodPed { get; set; }
        public int NroSeq { get; set;}
        public DateTime DataOcorrencia { get; set; }
        public string Obs { get; set; }
    }
}