using System;
using System.ComponentModel.DataAnnotations;

namespace API_MYSQL.Model
{
    public class Professor
    {
        public int id { get; set; }
        public string nome { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }
        public string horario { get; set; }

       
    }
}
