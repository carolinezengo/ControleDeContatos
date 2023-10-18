using ControleDeContatos.Data.Map;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext

    {
        public BancoContext()
        {

        }
        public BancoContext(DbContextOptions<BancoContext> options):base(options)
        { 
                
        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ContatoModel> Contato { get; set; }

        //Relacao de tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);

        }



    }
}
