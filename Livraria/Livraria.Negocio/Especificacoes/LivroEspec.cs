using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Entidade;
using Livraria.Negocio.Contrato;
using Livraria.Repositorio.Contrato;

namespace Livraria.Negocio.Especificacoes
{
    public class LivroEspec:ILivroEspec
    {
        #region Atributo para injeção de dependencia
        //atributo utilizado para injeção de dependencia
        private ILivroRep repositorio;
        public LivroEspec(ILivroRep repositorio)
        {
            this.repositorio = repositorio;
        }
        #endregion

        public bool ISBNIgualEspec(Livro l)
        {
            Livro livro = new Livro();

            l = repositorio.ConsultarPorISBN(l.ISBN);

            if (l == null)
            {
                return false;
            }
            else
            {
                throw new Exception("Já existe livro com o ISBN informado.");
            }
        }
    }
}
