using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
            _email = email;
        }

            public IActionResult Index()

            {
            //Se usuario estiver logado, redirecionar para a home
            
            
            if (_sessao.BuscarSessaoDoUsuario() != null)
            
                return RedirectToAction("Index", "Home");
                
            
                return View();
            
            
            }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                   
                   UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);
                   

                    if (usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemERRO"] = $"Senha do usuario invalida.";
                    }
                }
                TempData["MensagemERRO"] = $"Usuario s/ou senha invalida."; 

                return View("Index");

            }
            catch (Exception erro) 
            {

                TempData["MensagemERRO"] = $"Erro ao Logar. {erro.Message}";
                return RedirectToAction("Index");

            }




        }

        [HttpPost] 
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirsenhamodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLoginEEmail( redefinirsenhamodel.Login, redefinirsenhamodel.Email);
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuario.Email,"Sistema de contato nova senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Alterar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu email cadastro de uma nova senha";
                        }
                        else
                        {

                            TempData["MensagemERRO"] = $"Não conseguimos enviar o  email ";

                        }

                        return RedirectToAction("Index", "Login");
                       
                    }

                    TempData["MensagemERRO"] = $"Não conseguir definir a senha. Tente Novamente";


                }   
                return View("Index");
            }
              catch (Exception erro)
            {
                TempData["MensagemERRO"] = $"Não conseguimos redefinir sua senha";
                return RedirectToAction("Index");
            }   
        }

        public IActionResult RedefinirSenha()
        {
            return View();  
        }
    }
}
