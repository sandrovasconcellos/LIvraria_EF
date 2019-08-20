using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;
using Livraria.Entidade;
using Livraria.Repositorio.Mapeamento;


namespace Livraria.Repositorio.Contexto
{
    public class DataContexto : DbContext
    {
        public DataContexto()
            : base(ConfigurationManager.ConnectionStrings["livraria"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LivroMap());
        }

        public DbSet<Livro> Livro { get; set; }
    }
}
