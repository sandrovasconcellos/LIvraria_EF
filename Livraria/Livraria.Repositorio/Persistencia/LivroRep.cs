using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Livraria.Entidade;
using Livraria.Repositorio.Contexto;
using Livraria.Repositorio.Contrato;

namespace Livraria.Repositorio.Persistencia
{
    public class LivroRep : BaseRep<Livro>, ILivroRep
    {
        public List<Livro> ConsultarPorAutor(string autor)
        {
            using (DataContexto ctx = new DataContexto())
            {
                return ctx.Livro
                        .Where(l => l.Autor.Contains(autor))
                        .ToList();
            }
        }
        public List<Livro> ConsultarPorNome(string nome)
        {
            using (DataContexto ctx = new DataContexto())
            {
                return ctx.Livro
                        .Where(l => l.Nome.Contains(nome))
                        .ToList();
            }
        }
        public List<Livro> ConsultarPorPreco(decimal precoMin, decimal precoMax)
        {
            using (DataContexto ctx = new DataContexto())
            {
                return ctx.Livro
                        .Where(l => l.Preco >= precoMin
                                 && l.Preco <= precoMax)
                        .OrderBy(l => l.Preco)
                        .ToList();
            }
        }
        public List<Livro> ConsultarPorDataPublicacao(DateTime dataIni, DateTime dataFim)
        {            
            using (DataContexto ctx = new DataContexto())
            {
                return ctx.Livro
                        .Where(l => l.DtPublicacao >= dataIni.Date
                                 && l.DtPublicacao <= dataFim.Date)
                        .OrderBy(l => l.DtPublicacao)
                        .ToList();
            }
        }

        public List<Livro> ConsultarPorDescImagemCapa(string descImagemCapa)
        {
            using (DataContexto ctx = new DataContexto())
            {
                return ctx.Livro
                        .Where(l => l.DescImagemCapa.Contains(descImagemCapa))
                        .ToList();
            }
        }

        public List<Livro> Ordenar(string atributo)
        {
            using (DataContexto ctx = new DataContexto())
            {
                List<Livro> lista = new List<Livro>();
                switch (atributo)
                {
                    case "ISBN":
                        lista = ctx.Livro.OrderBy(l => l.ISBN).ToList();
                        break;
                    case "Autor":
                        lista = ctx.Livro.OrderBy(l => l.Autor).ToList();
                        break;
                    case "Nome":
                        lista = ctx.Livro.OrderBy(l => l.Nome).ToList();
                        break;
                    case "Preco":
                        lista = ctx.Livro.OrderBy(l => l.Preco).ToList();
                        break;
                    case "DtPublicacao":
                        lista = ctx.Livro.OrderBy(l => l.DtPublicacao).ToList();
                        break;
                    case "DescImagemCapa":
                        lista = ctx.Livro.OrderBy(l => l.DescImagemCapa).ToList();
                        break;
                }

                return lista;   
            }
        }

        public Livro ISBNIgual(string ISBN)
        {
            using (DataContexto ctx = new DataContexto())
            {      
                Livro livro = new Livro();
                livro = ctx.Livro
                      .Find(ISBN);
                return livro;
            }
        }
    }
}
