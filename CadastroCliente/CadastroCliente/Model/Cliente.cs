using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Model
{
    public class Cliente
    {
        private string _cpf;
        public string Cpf 
        { 
            get => _cpf; 
            set => _cpf = 
                (Utilitarios.MetodosExtensao.ValidarCPF(_cpf) 
                ? _cpf : throw new Exception("CPF INVÁLIDO PAIZÃO"));
        }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Sexos Sexo { get; set; }
        public Endereco EnderecoResidencial { get; set; }   
        public ContaCorrente ContaInfo { get; set; }

        public string Exibir()
        {
            return $"CPF: {this.Cpf}\n" + 
             $"Nome: {this.Nome}\n" +
             $"Idade: {this.Idade}\n" +
             $"Sexo: {this.Sexo}\n" +
             $"Endereço: \n" +
             $"{this.EnderecoResidencial.Exibir()}";
        }
    }
}
