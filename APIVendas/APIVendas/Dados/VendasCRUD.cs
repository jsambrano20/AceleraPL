using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIVendas.Models;
using System.Data.Entity;

namespace APIVendas.Dados
{
    public class VendasCRUD
    {
        //Pesquisar

        //Retorna um Pedido em Especifico a partir do seu codigo
        public static Pedidos BuscarPedido(int Codigo)
        {
            using (var ctx = new VendasEntities())
            {
                return ctx.Pedidos.FirstOrDefault(p => p.Cod.Equals(Codigo));
            }
        }

        //Retorna todo o histórico de um pedido a partir do seu codigo
        public static IEnumerable<HistPedido> ListarHistorico(int Codigo)
        {
            using (var ctx = new VendasEntities())
            {
                var Pesquisa = (from A in ctx.HistPedido
                                where A.CodPed == Codigo
                                select A).ToList();

                return Pesquisa;
            }
        }

        //Retornar Todos os Pedidos
        public static IEnumerable<Pedidos> ListarPedidos()
        {
            using (var ctx = new VendasEntities())
            {
                return ctx.Pedidos.ToList();
            }
        }

        //Retorna todos os pedidos de um determinado CPF
        public static IEnumerable<Pedidos> ListarPedidosCPF(string Codigo)
        {
            using (var ctx = new VendasEntities())
            {
                var Pesquisa = (from A in ctx.Pedidos
                                where A.CPF == Codigo
                                select A).ToList();

                return Pesquisa;
            }
        }

        //Retorna todos os pedidos de um determinado STATUS
        public static IEnumerable<Pedidos> ListarPedidosStatus(string status)
        {
            using (var ctx = new VendasEntities())
            {
                var Pesquisa = (from A in ctx.Pedidos
                                where A.Status == status
                                select A).ToList();

                return Pesquisa;
            }
        }

        //Retorna o total de Novos Pedidos
        public static string TotalPedidosFeitos()
        {
            using (var ctx = new VendasEntities())
            {
                var Pesquisa = (from A in ctx.Pedidos
                                where A.Status == "FEITOS"
                                select A).Count().ToString();

                return Pesquisa;
            }
        }

        //OPERAÇÕES

        //Inclui Pedidos Histórico(Pedido 1 =>N Historicos
        public static void NovoHistorico(HistPedido Novo)
        {
            using (var ctx = new VendasEntities())
            {
                ctx.HistPedido.Add(Novo);
                ctx.SaveChanges();
            }
        }
        //Inclui um Historico a partir da mudança de status ou outro evento
        public static void IncluirHistorico(int CodPedido, string Obs)
        {
            HistPedido NovoHist = new HistPedido();
            NovoHist.CodPed = CodPedido;
            NovoHist.NroSeq = 0;
            NovoHist.DataOcorrencia = DateTime.Now;
            NovoHist.Obs = Obs;

            NovoHistorico(NovoHist);
        }

        //Inclui um Novo pedido. Imediatamente inclui o 1º Histórico
        public static void NovoPedidoCliente(Pedidos Novo)
        {
            using (var ctx = new VendasEntities())
            {
                ctx.Pedidos.Add(Novo);
                ctx.SaveChanges();
            }

            IncluirHistorico(Novo.Cod, "[CLIENTE] Pedido Incluído");
        }

        //Alteração de um Pedido
        public static void AlterarPedido(Pedidos Alterado)
        {
            using(var ctx = new VendasEntities())
            {
                ctx.Entry<Pedidos>(Alterado).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        //Ultimo codigo do Pedido

        public static string UltimoCodigoIncluido()
        {
            using (var ctx = new VendasEntities())
            {
                var Pesquisa = ctx.Pedidos.Max(a => a.Cod).ToString();
                return Pesquisa;
            }
        }

        //Altera o status de um pedido a partir da classe status
        //Imediatamente após a mudança, Incluir um historico

        public static void AlterarStatusPedido(Status Info)
        {
            Pedidos Alt = BuscarPedido(Info.CodPedido);
            Alt.Status = Info.NovoStatus;
            AlterarPedido(Alt);

            IncluirHistorico(Alt.Cod, Info.Obs);
        }

        //Faz avaliação de um pedido
        public static void AvaliarPedido(AvaliacaoPedido Info)
        {
            Pedidos Alt = BuscarPedido(Info.CodPedido);
            Alt.Status = "AVALIADO";
            AlterarPedido(Alt);

            Info.Avaliacao = "[CLIENTE] Avaliação: " + Info.Avaliacao;

            IncluirHistorico(Alt.Cod, Info.Avaliacao);
        }

        //Realiza o Cancelamento do Pedido
        public static void CancelarPedido(AvaliacaoPedido Info)
        {
            Pedidos Alt = BuscarPedido(Info.CodPedido);
            Alt.Status = "CANCELADO";
            AlterarPedido(Alt);

            Info.Avaliacao = "[CLIENTE] Motivo de Cancelamento: " + Info.Avaliacao;

            IncluirHistorico(Alt.Cod, Info.Avaliacao);
        }


    }
}