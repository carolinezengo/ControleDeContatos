using ControleDeContatos.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;


namespace ControleDeContatos.Helper
{
    public class Sessao : ISessao
    {    private readonly IHttpContextAccessor _httpCOntext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpCOntext = httpContext;    
        
        }
        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpCOntext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) 
                return null;

            
           var recebe = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
           return recebe;
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = Newtonsoft.Json.JsonConvert.SerializeObject(usuario);
            _httpCOntext.HttpContext.Session.SetString("sessaoUsuarioLogado",valor);


        }

        public void RemoverSessaoUsuario()
        {
            _httpCOntext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
