using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Entidade;
using Livraria.Negocio.Contrato;

namespace Livraria.Negocio.Validacoes
{
    public class LivroValidacao:ILivroValidacao
    {     

        public bool ValidaObjeto(Livro l)
        {
            if (l.ISBN == "")
            {
                throw new Exception("O ISBN é obrigatório.");
            }
            if (l.Autor == "")
            {
                throw new Exception("O autor é obrigatório.");
            }
            if (l.Nome == "")
            {
                throw new Exception("O nome é obrigatório.");
            }
            if (l.Preco == 0)
            {
                throw new Exception("O preço é obrigatório.");
            }
            if (l.DtPublicacao == null)
            {
                throw new Exception("A data de publicação é obrigatória.");
            }
            if (l.DescImagemCapa == "" && l.ImagemCapa != "")
            {
                throw new Exception("A foto é obrigatória.");
            }
            if (l.DescImagemCapa != "" && l.ImagemCapa == "")
            {
                throw new Exception("A descrição da foto é obrigatória.");
            }

            return true;
        }
        public bool ValidaPreco(decimal prIni, decimal prFim)
        {
            if (prIni > prFim)
            {
                throw new Exception("O preço inicial não pode ser maior que o preço final.");
            }
            return true;
        }
        public bool ValidaData(DateTime dtIni, DateTime dtFim)
        {
            if (dtIni > dtFim)
            {
                throw new Exception("A data inicial não pode ser maior que a data final.");
            }            
            return true;
        }       
    }
}
