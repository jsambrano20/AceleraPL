using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Model
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }

        public string Exibir()
        {
            return $"Logradouro: {this.Logradouro}\n" +
             $"Numero: {this.Numero}\n" +
             $"Cidade: {this.Cidade}\n" +
             $"Cep: {this.Cep}\n";
        }
    }
}
