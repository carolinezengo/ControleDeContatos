using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        List<UsuarioModel> Buscartodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel ListaPorId(int id);
        UsuarioModel Alterar(UsuarioModel usuario);
        bool Deletar(int id);

    }
}
