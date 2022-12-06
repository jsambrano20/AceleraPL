using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Models
{
    public class Nota
    {
        public int id { get; set; }
        public int idAluno { get; set; }
        public double nota { get; set; }
        public int IdMateria { get; set; }
    }
}