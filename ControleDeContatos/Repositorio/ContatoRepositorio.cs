using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco de edados 

           _bancoContext.Contato.Add(contato);  
            _bancoContext.SaveChanges();

            return contato; 
        }

        public List<ContatoModel> Buscartodos(int usuarioid)
        {
            return _bancoContext.Contato.Where(x => x.UsuarioId == usuarioid).ToList();
        }

        public ContatoModel ListaPorId(int id)
        {
            return _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Alterar(ContatoModel contato)
        {
         ContatoModel contatoDB = ListaPorId(contato.Id);
            if (contatoDB == null) throw new Exception("Houve um erro na atualização do Contato");
           
            contatoDB.Name = contato.Name;  
            contatoDB.Email = contato.Email;    
           contatoDB.Tel=contato.Tel;   
            _bancoContext.Contato.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        
        }

        public bool Deletar(int id)
        {
          ContatoModel contatoDb = ListaPorId(id);
            if (contatoDb == null) throw new Exception("Houve um erro na delecao do contato!");
            _bancoContext.Contato.Remove(contatoDb);
            _bancoContext.SaveChanges();    
            return true;
        }
    }
}
