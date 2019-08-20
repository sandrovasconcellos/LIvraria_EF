using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Livraria.Repositorio.Contexto;
using Livraria.Repositorio.Contrato;

namespace Livraria.Repositorio.Persistencia
{
    public class BaseRep<T> : IBaseRep<T>
        where T : class
    {
        public void Incluir(T obj)
        {
            using (DataContexto ctx = new DataContexto())
            {
                ctx.Entry(obj).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void Alterar(T obj)
        {
            using (DataContexto ctx = new DataContexto())
            {
                ctx.Entry(obj).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public void Excluir(T obj)
        {
            using (DataContexto ctx = new DataContexto())
            {
                ctx.Entry(obj).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public List<T> ConsultarTodos()
        {
            using (DataContexto ctx = new DataContexto())
            {
                return ctx.Set<T>().ToList();
            }
        }

        public T ConsultarPorISBN(string ISBN)
        {
            using (DataContexto ctx = new DataContexto())
            {                
                return ctx.Set<T>().Find(ISBN);
            }
        }
    }
}
