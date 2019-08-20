using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Entidade;

namespace Livraria.Negocio.Contrato
{
    public interface ILivroValidacao
    {
        bool ValidaObjeto(Livro l);
        bool ValidaPreco(decimal prIni, decimal prFim);
        bool ValidaData(DateTime dtIni, DateTime dtFim);
        
    }
}
