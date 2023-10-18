using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Contato")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o email do Contato")]
        [EmailAddress(ErrorMessage = "O email informado não e valido ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o tel do Contato")]
        [Phone(ErrorMessage = "O celular informado nao e valido")]
        public string Tel { get; set; }

        //relacionamento de tabelas
        public int? UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }


    }
}
