using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorLoginEEmail(string login, string email);
        List<UsuarioModel> Buscartodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel ListaPorId(int id);
        UsuarioModel Alterar(UsuarioModel usuario);
        bool Deletar(int id);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarsenha);

    }
}
