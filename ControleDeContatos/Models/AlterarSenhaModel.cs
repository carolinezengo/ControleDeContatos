using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual")]
        public string SenhaAtual     { get; set; }
        [Required(ErrorMessage = "Digitea senha nova")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirmaçã da senha")]
        [Compare("NovaSenha", ErrorMessage = "Senha não confere com a nova senha")]
        public string ConfirmaSenha { get; set; }
    }
}
