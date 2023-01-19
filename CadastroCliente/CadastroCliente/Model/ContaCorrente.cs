using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Model
{
    public class ContaCorrente
    {
        public int NumeroBanco { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; private set; }

        public Cliente ClienteInfo;

        public void EfetuarOperacao(double valor, Operacoes operacao = Operacoes.Deposito) 
        {
            switch (operacao)
            {
                case Operacoes.Deposito:
                    this.Saldo += valor;
                    break;
                case Operacoes.Saque:
                    this.Saldo -= valor;
                    break;
            }
        }

        public string Exibir()
        {
            string cliente = this.ClienteInfo != null ? this.ClienteInfo.Exibir() + '\n' : "";

            return $"{cliente}" +
                $"Banco: {this.NumeroBanco}" +
                $"Agência: {this.NumeroAgencia}" +
                $"Conta: {this.NumeroConta}" +
                $"Saldo: {this.Saldo}";
        }
    }
}
