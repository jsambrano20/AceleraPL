using System.ComponentModel.DataAnnotations;

namespace Aula01_MVCfull.Models
{
    public class ContatoModel
    {

        public int id { get; set; }

        [Required(ErrorMessage ="Digite o Nome do Contato")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Digite o Email do Contato")]
        [EmailAddress(ErrorMessage ="Favor inserir um email válido")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "Digite o Celular do Contato")]
        [Phone(ErrorMessage ="Inserir um telefone válido")]
        public string celular { get; set; }
        
        [Required(ErrorMessage = "Insere o Nascimento do Contato")]
        public DateTime nascimento { get; set; }

    }
}
