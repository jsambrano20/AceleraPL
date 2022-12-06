using Microsoft.AspNetCore.Mvc;
using API.src.Models;

namespace CadAlunos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
    public IEnumerable<Alunos> _alunos = new Alunos[]{
        new Alunos(){
            id = 1,
            nome = "nicolas",
            email = "teste@teste.com",
            telefone = "(43)99999-9999",
            CPF = "555.555.555.23",
            RG = "1212222332",
            imagemFoto = "img/user_1.png",
        },
         new Alunos(){
            id = 2,
            nome = "joao",
            email = "teste@teste.com",
            telefone = "(43)99999-9999",
            CPF = "555.555.555.23",
            RG = "1212222332",
            imagemFoto = "img/user_2.png",
        },
         new Alunos(){
            id = 3,
            nome = "douglas",
            email = "teste@teste.com",
            telefone = "(43)99999-9999",
            CPF = "555.555.555.23",
            RG = "1212222332",
            imagemFoto = "img/user_3.png",
        },
    };

    public AlunosController()
    {

    }

    [HttpGet]
    public IEnumerable<Alunos> Get()
    {
        return _alunos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Alunos> GetbyId(int id)
    {
        return _alunos.Where(Alunos => Alunos.id == id);


    }

    [HttpPost]
    public string Post()
    {
        return "Return Post";
    }
}
