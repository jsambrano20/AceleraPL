using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices.Internal;

namespace Aula04_AdoNet.Models
{
    public class Repositorio
    {
        SqlConnection sqlConnection = new SqlConnection();                 //Conexao
        SqlCommand sqlCommand = new SqlCommand();               //Comando executar
        SqlDataAdapter reader = new SqlDataAdapter();           //executa o comando
        DataSet DS = new DataSet();                             //Recebe a tabela e a mantem offline


        public DataSet VoltaClientes()
        {
            //Servidor, banco, user e senha
            sqlConnection.ConnectionString = "Data Source=localhost;initial catalog=CursoAsp;Trusted_Connection=True;";


            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM Clientes";
            
            // se vincula ao comandop
            reader.SelectCommand= sqlCommand;

            //abrir conexão com banco
            sqlConnection.Open();

            //Tipos de execução
            reader.Fill(DS);

            //sqlCommand.ExecuteNonQuery(); //sem retorno (i u d)
            //sqlCommand.ExecuteScalar();       //retorna um valor


            //sempre fechar após utilizar
            sqlConnection.Close();
            return DS;

        }
    }
}