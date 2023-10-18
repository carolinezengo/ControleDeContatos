using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeContatos.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        //relacionamento de tabela
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
           builder.HasKey(x => x.Id);
           builder.HasOne(x => x.Usuario);


        }
    }
}
