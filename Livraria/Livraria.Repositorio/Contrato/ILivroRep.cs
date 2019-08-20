using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Entidade;

namespace Livraria.Repositorio.Contrato
{
    public interface ILivroRep : IBaseRep<Livro>
    {
        List<Livro> ConsultarPorAutor(string autor);
        List<Livro> ConsultarPorNome(string nome);
        List<Livro> ConsultarPorPreco(decimal precoMin, decimal precoMax);
        List<Livro> ConsultarPorDataPublicacao(DateTime dataIni, DateTime dataFim);
        List<Livro> ConsultarPorDescImagemCapa(string descImagemCapa);        
        List<Livro> Ordenar(string atributo);
        Livro ISBNIgual(string isbn);
    }
}
