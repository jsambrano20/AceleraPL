using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjecaoDep
{
    //Nivel 1 - UMA GRANDE CLASSE
    //Nivel 2 - Varias Classes com dependencia - FORTE Acoplamento
    //Nivel 3 - Injeção de Dependencia - FRACO Acoplamento

    //Nivel 2 - Varias Classes com dependencia - FORTE Acoplamento
    //public class BancoBradesco
    //{
    //    public void EnviarPix()
    //    {

    //    }
    //}

    //public class Pagamentos
    //{
    //    public void PagarConta()
    //    {
    //        BancoBradesco banco = new BancoBradesco();
    //        banco.EnviarPix();
    //    }
    //}

    //public class MeuSistema
    //{
    //    public void Pagar()
    //    {

    //        Pagamentos conta = new Pagamentos();
    //        conta.PagarConta();
    //    }
    //}


    //Nivel 3 - Injeção de Dependencia - FRACO Acoplamento
    public interface IBanco
    {
        void Conectar();
        void EnviarPix();
    }

    public class BancoBradesco : IBanco
    {
        public void Conectar()
        {
            throw new NotImplementedException();
        }

        public void EnviarPix()
        {
            throw new NotImplementedException();
        }
    }
    public class BancoSantader : IBanco
    {
        public void Conectar()
        {
            throw new NotImplementedException();
        }

        public void EnviarPix()
        {
            throw new NotImplementedException();
        }
    }
    public class Pagamentos
    {
        IBanco MeuBanco;
        
        //Constructor Injection Dependency
        public Pagamentos(IBanco banco)
        {
            this.MeuBanco = banco;
        }

        public void Transferir()
        {
            MeuBanco.Conectar();
            MeuBanco.EnviarPix();
        }

        //Method Injection Dependency
        //public void Transferir(IBanco a)
        //{
        //    a.Conectar();
        //    a.EnviarPix();
        //}

    }

    public class MeuSistema
    {
        public void fechamentomes()
        {
            BancoBradesco bk1 = new BancoBradesco();
            Pagamentos pagamentos = new Pagamentos(bk1);
            pagamentos.Transferir();    
        }
    }
}
