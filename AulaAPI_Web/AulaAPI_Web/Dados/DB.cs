using AulaAPI_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaAPI_Web.Dados
{
    public class DB
    {
        public static List<Alunos> alunos = new List<Alunos>()
        {
            new Alunos() { Codigo=1, Nome="Joao"},
            new Alunos() { Codigo=2, Nome="Nicolas"},
            new Alunos() { Codigo=3, Nome="Douglas"},
            new Alunos() { Codigo=4, Nome="Giovana"},
            new Alunos() { Codigo=5, Nome="Daniel"}
        };

        public static IEnumerable<Alunos> ListarAlunos()
        {
            return alunos;
        }

        public static IEnumerable<string> ListarMaterias()
        {
            return new List<string> { "Matematica", "Portugues", "Quimica" };
        }
    }
}