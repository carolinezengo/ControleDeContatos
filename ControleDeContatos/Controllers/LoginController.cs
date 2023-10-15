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

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
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
    }
}
