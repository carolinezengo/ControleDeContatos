using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> Buscartodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel ListaPorId(int id);
        UsuarioModel Alterar(UsuarioModel usuario);
        bool Deletar(int id);

    }
}
