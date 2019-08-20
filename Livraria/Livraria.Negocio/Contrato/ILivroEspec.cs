using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Entidade;

namespace Livraria.Negocio.Contrato
{
    public interface ILivroEspec
    {
        Boolean ISBNIgualEspec(Livro l);
    }
}
