using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using APIVendas.Models;
using APIVendas.Dados;

namespace APIVendas.Controllers
{
    //Prefixo da Rota da API
    [RoutePrefix("api/vendas")]
    public class VendasController : ApiController
    {
        //Pesquisas

        //Retorna um Pedido a partir do código
        [HttpGet, Route("BuscarPedido/{id}")]
        public Pedidos BuscarPedido(int id)
        {
            return VendasCRUD.BuscarPedido(id);
        }

        //Retorna Lista de Historico de um Pedido
        [HttpGet, Route("BuscarHistorico/{id}")]
        public IEnumerable<HistPedido> BuscarHistorico(int id)
        {
            return VendasCRUD.ListarHistorico(id);
        }

        //Retorna todos os Pedidos
        [HttpGet, Route("ListarPedidos")]
        public IEnumerable<Pedidos> ListarPedidos()
        {
            return VendasCRUD.ListarPedidos();
        }

        //Retorna todos os Pedidos por CPF
        [HttpGet, Route("ListarPedidosCPF/{id}")]
        public IEnumerable<Pedidos> ListarPedidosCPF(string id)
        {
            return VendasCRUD.ListarPedidosCPF(id);
        }

        //Retorna todos os Pedidos por Status
        [HttpGet, Route("ListarPedidosStatus/{id}")]
        public IEnumerable<Pedidos> ListarPedidosStatus(string id)
        {
            return VendasCRUD.ListarPedidosStatus(id);
        }

        //Retorna o total de pedidos novos
        [HttpGet, Route("TotalPedidosFeitos")]
        public string TotalPedidos()
        {
            return VendasCRUD.TotalPedidosFeitos();
        }


        //OPERAÇÕES

        //incluir Pedido
        [HttpPost, Route("NovoPedido")]
        public string IncluirPedido(Pedidos Novo)
        {
            try
            {
                VendasCRUD.NovoPedidoCliente(Novo);
                return "Ok";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        //Mudar Status
        [HttpPost, Route("MudarStatusPedido")]
        public string MudarStatus(Status Mudou)
        {
            try
            {
                VendasCRUD.AlterarStatusPedido(Mudou);
                return "Ok";
            }
            catch (Exception err)
            {
                return err.Message;

            }
        }

        //Faz avaliação de pedido por cliente
        [HttpPut, Route("AvaliarPedido")]
        public string PedidoAvaliado(AvaliacaoPedido info)
        {
            try
            {
                VendasCRUD.AvaliarPedido(info);
                return "Ok";
            }
            catch (Exception err)
            {
                return err.Message;

            }
        }

        //Faz cancelamento do Pedido pelo Cliente
        [HttpPut, Route("CancelarPedido")]
        public string PedidoCancelado(AvaliacaoPedido info)
        {
            try
            {
                VendasCRUD.CancelarPedido(info);
                return "Ok";
            }
            catch (Exception err)
            {
                return err.Message;

            }
        }

        [HttpPut, Route("DevolvePedidoCliente")]
        public string DevolvePedidoCliente(AvaliacaoPedido info)
        {
            try
            {

                VendasCRUD.DevolvePedidoCliente(info);


                return "Ok";


            }
            catch (Exception err)
            {
                return err.Message;

            }
        }

    }
}
