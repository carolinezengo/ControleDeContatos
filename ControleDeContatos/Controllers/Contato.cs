using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaUsuarioLogado]
    public class Contato : Controller
    {
        
        private readonly IContatoRepositorio _contatoRepositorio;
       
        public Contato(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;   
        }
        //metodo get
        public IActionResult Index()
            
        {
         List <ContatoModel> contatos = _contatoRepositorio.Buscartodos();

            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListaPorId(id);
            return View(contato);
        }
        public IActionResult DeletarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListaPorId(id);
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            try
            {

                _contatoRepositorio.Deletar(id);
                TempData["MensagemSucesso"] = "Contato Apagado com sucesso";

                return RedirectToAction("Index");
            }
            catch (System.Exception erro) {
                TempData["MensagemERRO"] = $"Não conseguiu deletar o contato {erro.Message}";// { erro.Message} msg de erro
                return RedirectToAction("Index");


            }
        }

        //metodo post

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    //armazanamento temporario
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemERRO"] = $"Não conseguiu cadastrar o contato { erro.Message}";// { erro.Message} msg de erro
                return RedirectToAction("Index");
            }

               
        }
      
        [HttpPost]
       public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Alterar(contato);
                    TempData["MensagemSucesso"] = "Contato Atualizado com sucesso";
                    return RedirectToAction("Index");

                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch ( System.Exception erro) { 

                    TempData["MensagemERRO"] = $"Não conseguiu atualizar o contato {erro.Message}";// { erro.Message} msg de erro
                return RedirectToAction("Index");

            }

            
        }
        

       
    }
}
