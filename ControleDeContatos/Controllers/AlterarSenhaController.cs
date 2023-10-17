using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;



namespace ControleDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;   
        }

            public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarsenhamodel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();

                alterarsenhamodel.Id = usuarioLogado.Id;
                if (ModelState.IsValid)
                { 
                    
                    _usuarioRepositorio.AlterarSenha(alterarsenhamodel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarsenhamodel);

                }

                return View("Index", alterarsenhamodel);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemERRO"] = $"Não conseguiu atualizar a senha {erro.Message}";// { erro.Message} msg de erro
                return RedirectToAction("Index", alterarsenhamodel);

            }
        }
    }
}
