using AulaAPI_Web.Dados;
using AulaAPI_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AulaAPI_Web.Controllers
{
    [RoutePrefix("api/alunos")]
    public class AlunosController : ApiController
    {
        [HttpGet,Route("ListarMaterias")]
        public IEnumerable<string> GetMaterias()
        {
            return DB.ListarMaterias();
        }

        [HttpGet, Route("ListarAlunos")]
        public IEnumerable<Alunos> GetAlunos()
        {
            return DB.ListarAlunos();
        }

        [HttpGet, Route("PesquisarMaterias/{id}")]
        public string PesqMateria(string id)
        {
            List<string> mats = (List<string>)DB.ListarMaterias();
            return mats.Find(p => p.Contains(id));
        }

        [HttpGet, Route("PesquisarAlunos/{id}")]
        public Alunos PesqAlunos(int id)
        {
            List<Alunos> alunos = (List<Alunos>)DB.ListarAlunos();
            return alunos.Find(p => p.Codigo == id);
        }
    }
}
