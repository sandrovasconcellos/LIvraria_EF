using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Livraria.Entidade;

namespace Livraria.Repositorio.Mapeamento
{
    public class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            //nome da tabela..
            ToTable("Livro");

            //chave primária..
            HasKey(l => l.ISBN);

            //campos da tabela..
            Property(l => l.ISBN)
                .HasColumnName("ISBN")
                .IsRequired()
                .HasMaxLength(13);

            Property(l => l.Autor)
                .HasColumnName("Autor")
                .IsRequired()
                .HasMaxLength(100);

            Property(l => l.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(100);

            Property(l => l.Preco)
                .HasColumnName("Preco")
                .HasPrecision(18, 2)
                .IsRequired();

            Property(l => l.DtPublicacao)
                .HasColumnName("DtPublicacao")
                .IsRequired();

            Property(l => l.ImagemCapa)
                .HasColumnName("ImagemCapa");

            Property(l => l.DescImagemCapa)
                .HasColumnName("DescImagemCapa")
                .HasMaxLength(100);

        }
    }
}
