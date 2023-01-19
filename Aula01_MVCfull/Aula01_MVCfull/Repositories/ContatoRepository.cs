using Aula01_MVCfull.Data;
using Aula01_MVCfull.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01_MVCfull.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContextcs _context;
        public ContatoRepository(AppDbContextcs context)
        {
            _context = context;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.contato.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel BuscarporID(int id)
        {
            return _context.contato.FirstOrDefault(x => x.id == id);
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoEdit = BuscarporID(contato.id);

            if (contatoEdit == null)
                throw new Exception("Id nao encontado");

            _context.contato.Update(contatoEdit);
            _context.SaveChanges();
            return contatoEdit;
        }


        public List<ContatoModel> ListarContatos()
        {
            return _context.contato.ToList();
        }

        public bool Excluir(int id)
        {
            ContatoModel contato = BuscarporID(id);

            if (contato == null)
                throw new Exception("Id nao encontado");

            _context.contato.Remove(contato);
            _context.SaveChanges();
            return true;
        }
    }
}
