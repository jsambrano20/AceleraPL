using Microsoft.AspNetCore.Mvc;
using API.src.Models;

namespace CadProfessor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfessorController : ControllerBase
{
    public IEnumerable<Professor> _Professor = new Professor[]{
        new Professor(){
            id = 1,
            nome = "Neymar",
            email = "teste@teste.com",
            telefone = "(43)99999-9999",
            horario = "Manhã"
        },
         new Professor(){
            id = 2,
            nome = "Dudu",
            email = "teste@teste.com",
            telefone = "(43)99999-9999",
            horario = "Tarde"


        },
         new Professor(){
            id = 3,
            nome = "Káka",
            email = "teste@teste.com",
            telefone = "(43)99999-9999",
            horario = "Noite"

        },
    };

    public ProfessorController()
    {

    }

    [HttpGet]
    public IEnumerable<Professor> Get()
    {
        return _Professor;
    }

    [HttpGet("{id}")]
    public IEnumerable<Professor> GetbyId(int id)
    {
        return _Professor.Where(Professor => Professor.id == id);


    }

    [HttpPost]
    public string Post()
    {
        return "Return Post";
    }
}
