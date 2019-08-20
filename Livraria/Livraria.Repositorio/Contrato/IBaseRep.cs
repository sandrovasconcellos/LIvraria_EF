using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Repositorio.Contrato
{
    public interface IBaseRep<T>  where T : class
    {
        void Incluir(T obj);

        void Alterar(T obj);

        void Excluir(T obj);

        List<T> ConsultarTodos();

        T ConsultarPorISBN(string ISBN);
    }
}
