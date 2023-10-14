using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> Buscartodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel ListaPorId(int id);    
        ContatoModel Alterar(ContatoModel contato);
        bool Deletar(int id);

    }
}
