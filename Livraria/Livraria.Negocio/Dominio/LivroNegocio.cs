using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Entidade;
using Livraria.Negocio.Contrato;
using Livraria.Repositorio.Contrato;



namespace Livraria.Negocio.Dominio
{
    public class LivroNegocio : ILivroNegocio
    {
        #region Atributo para injeção de dependencia

        //atributo utilizado para injeção de dependencia
        private ILivroRep repositorio;
        private ILivroEspec lEspec;
        private ILivroValidacao lValid;

        public LivroNegocio(ILivroRep repositorio, ILivroEspec lEspec, ILivroValidacao lValid)
        {
            this.repositorio = repositorio;
            this.lEspec = lEspec;
            this.lValid = lValid;
        }
        #endregion

        

        public void Incluir(Livro l)
        {
            if ((lValid.ValidaObjeto(l)) && (!lEspec.ISBNIgualEspec(l)))
            {
                repositorio.Incluir(l);
            }
        }
        public void Alterar(Livro l)
        {
            if (lValid.ValidaObjeto(l))
            {
                repositorio.Alterar(l);
            }
        }
        public void Excluir(Livro l)
        {
            repositorio.Excluir(l);
        }
        public List<Livro> ConsultarTodos()
        {
            List<Livro> lista = repositorio.ConsultarTodos();
            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("Nenhum livro foi encontrado.");
            }
        }
        public Livro ConsultarPorISBN(string ISBN)
        {
            Livro l = repositorio.ConsultarPorISBN(ISBN);
            if( l != null)
            {
                return l;
            }
            else
            {
                throw new Exception("O Livro não foi encontrado.");
            }                        
        }
        public List<Livro> ConsultarPorAutor(string autor)
        {
            List<Livro> lista = repositorio.ConsultarPorAutor(autor);
            if(lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("O autor não foi encontrado.");
            }
            
        }
        public List<Livro> ConsultarPorNome(string nome)
        {
            List<Livro> lista = repositorio.ConsultarPorNome(nome);
            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("O nome do livro não foi encontrado.");
            }            
        }
        public List<Livro> ConsultarPorPreco(decimal precoMin, decimal precoMax)
        {
            List<Livro> lista = new List<Livro>();

            if (lValid.ValidaPreco(precoMin, precoMax))
            {
                lista = repositorio.ConsultarPorPreco(precoMin, precoMax);
            }
            
            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("O preço não foi encontrado.");
            }
        }
        public List<Livro> ConsultarPorDataPublicacao(DateTime dataIni, DateTime dataFim)
        {
            List<Livro> lista = new List<Livro>();

            if (lValid.ValidaData(dataIni, dataFim))
            {
                lista = repositorio.ConsultarPorDataPublicacao(dataIni, dataFim);
            }

            if (lista.Count > 0)
                {
                    return lista;
                }
                else
                {
                    throw new Exception("Não foi encontrado livro no período informado.");
                }
            }
        
        public List<Livro> ConsultarPorDescImagemCapa(string descImagemCapa)
        {
            List<Livro> lista = repositorio.ConsultarPorDescImagemCapa(descImagemCapa);
            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                throw new Exception("A descrição da imagem da capa não foi encontrada.");
            }
        }
        public List<Livro> Ordenar(string atributo)
        {
            return repositorio.Ordenar(atributo);
        }       

    }
}
