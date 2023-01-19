using System;
using System.ComponentModel.DataAnnotations;

namespace API_MYSQL.Model
{
    public class Materias
    {
        public int id { get; set; }
        public string materia { get; set; }
        public string descricao { get; set; }
    }
}
