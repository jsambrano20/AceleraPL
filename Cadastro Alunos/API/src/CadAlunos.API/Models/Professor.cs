using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Models
{
    public class Professor
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? telefone { get; set; }
        public string? horario { get; set; }
    }
}