using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> Buscartodos(int usuarioid);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel ListaPorId(int id);    
        ContatoModel Alterar(ContatoModel contato);
        bool Deletar(int id);

    }
}
