using Projeto02_Entity.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto02_Entity.Repositorio
{
    public class AlunosRepo
    {

        public static void NovoAluno(Alunos alunos)
        {
            using (var context = new escolaEntities())
            {
                context.Alunos.Add(alunos);
                context.SaveChanges();
            }
        }

        //Pesquisar individual
        public static Alunos PesquisarAluno(int cod)
        {
            using (var context = new escolaEntities())
            {
                return context.Alunos.FirstOrDefault(x => x.Cod.Equals(cod));
            }
        }

        //Pesquisar todos
        public static IEnumerable<Alunos> ListarAlunos()
        {
            using (var context = new escolaEntities())
            {
                return context.Alunos.ToList();
            }
        }

        //Metodo para alterar um cliente

        public static void AlterarAluno(Alunos alterado)
        {
            using (var context = new escolaEntities())
            {
                context.Entry<Alunos>(alterado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void ApagarAluno(Alunos alterado)
        {
            using (var context = new escolaEntities())
            {
                context.Entry<Alunos>(alterado).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}