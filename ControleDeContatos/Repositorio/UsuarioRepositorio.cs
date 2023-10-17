using ControleDeContatos.Controllers;
using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Data;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio :IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro=DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel Alterar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListaPorId(usuario.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do Contato");

            usuarioDB.Name = usuario.Name;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;
            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorLoginEEmail(string login, string email)
        {
            return 
            _bancoContext.Usuario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }

        public List<UsuarioModel> Buscartodos()
        {
            return _bancoContext.Usuario.ToList();
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuarioDb = ListaPorId(id);
            if (usuarioDb == null) throw new Exception("Houve um erro na delecao do contato!");
            _bancoContext.Usuario.Remove(usuarioDb);
            _bancoContext.SaveChanges();
            return true;

        }

        public UsuarioModel ListaPorId(int id)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarsenha)
        {
            UsuarioModel usuarioDB = ListaPorId(alterarsenha.Id);

            // se nao achar o usuario
            if (usuarioDB == null) throw new Exception("Houve um erro na alteração da senha, usuario não encontrado!");

            // verificar se a senha atual e a que esta no banco 
            if (!usuarioDB.SenhaValida(alterarsenha.SenhaAtual)) throw new Exception("Senha atual não confere!");

            //verificar se a nova senha seja diferente da atual
            if (usuarioDB.SenhaValida(alterarsenha.NovaSenha)) throw new Exception("Senha atual não confere!");

            usuarioDB.SetNovaSenha(alterarsenha.NovaSenha);
            usuarioDB.DataAtualizacao =  DateTime.Now;

            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges(); 
            
            return usuarioDB;  
        }
    }
}
