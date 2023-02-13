using Projeto02_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto02_MVC.Data
{
    public class NotasRepo
    {

        public static void NovoNota(Notas notas)
        {
            using (var context = new EscolaEntities())
            {
                context.Notas.Add(notas);
                context.SaveChanges();
            }
        }

        //Pesquisar individual
        public static Notas PesquisarNota(int cod)
        {
            using (var context = new EscolaEntities())
            {
                return context.Notas.FirstOrDefault(x => x.CodNot.Equals(cod));
            }
        }

        //Pesquisar todos
        public static IEnumerable<Notas> ListarNotas()
        {
            using (var context = new EscolaEntities())
            {
                return context.Notas.ToList();
            }
        }

        //Metodo para alterar um cliente

        public static void AlterarNota(Notas alterado)
        {
            using (var context = new EscolaEntities())
            {
                context.Entry<Notas>(alterado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void ApagarNota(Notas alterado)
        {
            using (var context = new EscolaEntities())
            {
                context.Entry<Notas>(alterado).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}