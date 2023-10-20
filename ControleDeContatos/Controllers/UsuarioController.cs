using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IContatoRepositorio _contatorepositorio;


        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IContatoRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatorepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.Buscartodos();

            return View(usuarios);
            

        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    //armazanamento temporario
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemERRO"] = $"Não conseguiu cadastrar o usuario {erro.Message}";// { erro.Message} msg de erro
                return RedirectToAction("Index");
            }


        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListaPorId(id);
            return View(usuario);
        }
        public IActionResult DeletarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListaPorId(id);
            return View(usuario);
        }

        public IActionResult Deletar(int id)
        {
            try
            {

                _usuarioRepositorio.Deletar(id);
                TempData["MensagemSucesso"] = "Contato Apagado com sucesso";

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemERRO"] = $"Não conseguiu deletar o contato {erro.Message}";// { erro.Message} msg de erro
                return RedirectToAction("Index");


            }
        }
        // preencher a tabela modal
        public IActionResult ListarContatosPorUsuarioId(int id)
        {
            List<ContatoModel> contatos = _contatorepositorio.Buscartodos(id);
            return PartialView("_ContatosUsuario", contatos);
        }
        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Alterar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Atualizado com sucesso";
                    return RedirectToAction("Index");

                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemERRO"] = $"Não conseguiu atualizar o usuario {erro.Message}";// { erro.Message} msg de erro
                return RedirectToAction("Index");

            }


        }

    }

}
