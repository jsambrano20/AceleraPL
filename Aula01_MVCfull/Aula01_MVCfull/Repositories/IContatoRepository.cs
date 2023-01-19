using Aula01_MVCfull.Models;

namespace Aula01_MVCfull.Repositories
{
    public interface IContatoRepository
    {
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        List<ContatoModel> ListarContatos();
        ContatoModel BuscarporID(int id);
        bool Excluir(int id);
    }
}
