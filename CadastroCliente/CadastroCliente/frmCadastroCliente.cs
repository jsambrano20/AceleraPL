using CadastroCliente.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitarios;

namespace CadastroCliente
{
    public partial class frmCadastroCliente : Form
    {
        public frmCadastroCliente()
        {
            InitializeComponent();

            cbSexo.Items.Add(Sexos.Masculino);
            cbSexo.Items.Add(Sexos.Feminino);
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContaCorrente contaCorrente = new ContaCorrente()
            {
                NumeroConta = txtConta.Text,
                NumeroAgencia= txtAgencia.Text,
                NumeroBanco =int.Parse(txtBanco.Text)
            };

            MessageBox.Show(contaCorrente.Exibir());

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Inserir os Dados do Endereço

            Endereco endereco = new Endereco()
            {
                Logradouro = txtLogradouro.Text,
                Cidade = txtCidade.Text,
                Cep = txtCep.Text,
                Numero = Convert.ToInt32(txtNumero.Text)
            };

            Cliente cliente = new Cliente()
            {
                Nome = txtNome.Text,
                //Cpf  = txtCPF.Text,
                Sexo = (Sexos)cbSexo.SelectedItem,
                Idade = Convert.ToInt32(txtIdade.Text),
                EnderecoResidencial = endereco
            }; 

            MessageBox.Show(cliente.Exibir());
        }
    }
}
