using Aula05_Daniel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.ModelBinding;

namespace Aula05_Daniel.Dados
{
    public class Repositorio
    {
        //Metodo para incluir um cliente

        public static void NovoCliente(Clientes clientes)
        {
            using (var context = new CursoAspEntities())
            {
                context.Clientes.Add(clientes);
                context.SaveChanges();
            }
        }

        //Pesquisar individual
        public static Clientes PesquisarCliente(int cod)
        {
            using (var context = new CursoAspEntities())
            {
                return context.Clientes.FirstOrDefault(x => x.Cod.Equals(cod));
            }
        }

        //Pesquisar todos
        public static IEnumerable<Clientes> ListarClientes()
        {
            using (var context = new CursoAspEntities())
            {
                return context.Clientes.ToList();
            }
        }

        //Metodo para alterar um cliente

        public static void AlterarCliente(Clientes alterado)
        {
            using (var context = new CursoAspEntities())
            {
                context.Entry<Clientes>(alterado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void ApagarCliente(Clientes alterado)
        {
            using (var context = new CursoAspEntities())
            {
                context.Entry<Clientes>(alterado).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}