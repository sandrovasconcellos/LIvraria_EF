using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Livraria.Entidade;
using Livraria.Negocio.Contrato;
using Livraria.Servico.Models;
using Livraria.Servico.Utilitario;

using System.IO;
using System.Web;


namespace Livraria.Servico.Controllers
{
    [RoutePrefix("api/livro")]
    public class LivroController : ApiController
    {
        #region Atributo para injeção de dependencia
        private ILivroNegocio negocio;

        public LivroController(ILivroNegocio negocio)
        {
            this.negocio = negocio;
        }
        #endregion
        
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Cadastrar(LivroCadastrarModel model)
        {          
            if (ModelState.IsValid)
            {
                try
                {
                    Livro l = new Livro();
                    l.ISBN = model.ISBN;
                    l.Autor = model.Autor;
                    l.Nome = model.Nome;
                    l.Preco = model.Preco;
                    l.DtPublicacao = model.DtPublicacao.Date;
                    l.DescImagemCapa = model.DescImagemCapa;
                    l.ImagemCapa = model.ImagemCapa;
                   
                    negocio.Incluir(l);                  

                    return Request.CreateResponse(HttpStatusCode.OK, $"Livro {l.Nome}, cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);                    
                }
            }
            else
            {
                //retornar status de erro (400 - BadRequest)                  
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelStateUtil.GetValidationMessages(ModelState));
            }
        }

        [HttpPut]
        [Route("alterar")]
        public HttpResponseMessage Alterar(LivroAlterarModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //consulta a existencia do livro
                    Livro banco = negocio.ConsultarPorISBN(model.ISBN);

                    Livro l = new Livro();
                    l.ISBN = model.ISBN;
                    l.Autor = model.Autor;
                    l.Nome = model.Nome;
                    l.Preco = model.Preco;
                    l.DtPublicacao = model.DtPublicacao.Date;
                    l.DescImagemCapa = model.DescImagemCapa;
                    l.ImagemCapa = model.ImagemCapa;

                    negocio.Alterar(l);

                    return Request.CreateResponse(HttpStatusCode.OK, $"Livro {l.Nome}, alterado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelStateUtil.GetValidationMessages(ModelState));
                //return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(e => e.Errors.Select(s => s.ErrorMessage)));
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Excluir(string ISBN)
        {
            try
            {
                //consulta a existencia do livro
                Livro l = negocio.ConsultarPorISBN(ISBN);

                negocio.Excluir(l); //excluindo..

                return Request.CreateResponse(HttpStatusCode.OK, $"Livro {l.Nome}, excluido com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar")]
        public HttpResponseMessage ConsultarTodos()
        {
            try
            {
                List<LivroConsultarModel> lista = new List<LivroConsultarModel>();

                foreach (Livro l in negocio.ConsultarTodos())
                {
                    LivroConsultarModel model = new LivroConsultarModel();

                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = Convert.ToDateTime(l.DtPublicacao);
                    model.DescImagemCapa = l.DescImagemCapa;
                    model.ImagemCapa = l.ImagemCapa;

                    lista.Add(model); //adicionar na lista..
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse (HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar_por_isbn")]
        public HttpResponseMessage ConsultarPorISBN(string ISBN)
        {
            try
            {
                LivroConsultarModel model = new LivroConsultarModel();
                Livro l = negocio.ConsultarPorISBN(ISBN);
                model.ISBN = l.ISBN;
                model.Autor = l.Autor;
                model.Nome = l.Nome;
                model.Preco = l.Preco;
                model.DtPublicacao = Convert.ToDateTime(l.DtPublicacao);
                model.DescImagemCapa = l.DescImagemCapa;
                model.ImagemCapa = l.ImagemCapa;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar_por_autor")]
        public HttpResponseMessage ConsultarPorAutor(string autor)
        {
            try
            {
                List<LivroConsultarModel> lista = new List<LivroConsultarModel>();

                foreach (Livro l in negocio.ConsultarPorAutor(autor))
                {
                    LivroConsultarModel model = new LivroConsultarModel();

                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = Convert.ToDateTime(l.DtPublicacao);
                    model.DescImagemCapa = l.DescImagemCapa;
                    model.ImagemCapa = l.ImagemCapa;

                    lista.Add(model); //adicionar na lista..
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar_por_nome")]
        public HttpResponseMessage ConsultarPorNome(string nome)
        {
            try
            {
                List<LivroConsultarModel> lista = new List<LivroConsultarModel>();

                foreach (Livro l in negocio.ConsultarPorNome(nome))
                {
                    LivroConsultarModel model = new LivroConsultarModel();

                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = Convert.ToDateTime(l.DtPublicacao);
                    model.DescImagemCapa = l.DescImagemCapa;
                    model.ImagemCapa = l.ImagemCapa;

                    lista.Add(model); //adicionar na lista..
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar_por_preco")]
        public HttpResponseMessage ConsultarPorPreco(decimal precoIni, decimal precoFim)
        {
            try
            {
                List<LivroConsultarModel> lista = new List<LivroConsultarModel>();

                foreach (Livro l in negocio.ConsultarPorPreco(precoIni, precoFim))
                {
                    LivroConsultarModel model = new LivroConsultarModel();

                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = Convert.ToDateTime(l.DtPublicacao);
                    model.DescImagemCapa = l.DescImagemCapa;
                    model.ImagemCapa = l.ImagemCapa;

                    lista.Add(model); //adicionar na lista..
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar_por_data_publicacao")]
        public HttpResponseMessage ConsultarPorDataPublicacao(DateTime dataIni, DateTime dataFim)
        {
            try
            {
                List<LivroConsultarModel> lista = new List<LivroConsultarModel>();

                foreach (Livro l in negocio.ConsultarPorDataPublicacao(dataIni, dataFim))
                {
                    LivroConsultarModel model = new LivroConsultarModel();

                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = Convert.ToDateTime(l.DtPublicacao);
                    model.DescImagemCapa = l.DescImagemCapa;
                    model.ImagemCapa = l.ImagemCapa;

                    lista.Add(model); //adicionar na lista..
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar_por_descricao_imagem_capa")]
        public HttpResponseMessage ConsultarPorDescImagemCapa(string descImagemCapa)
        {
            try
            {
                List<LivroConsultarModel> lista = new List<LivroConsultarModel>();

                foreach (Livro l in negocio.ConsultarPorDescImagemCapa(descImagemCapa))
                {
                    LivroConsultarModel model = new LivroConsultarModel();

                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = Convert.ToDateTime(l.DtPublicacao);
                    model.DescImagemCapa = l.DescImagemCapa;
                    model.ImagemCapa = l.ImagemCapa;

                    lista.Add(model); //adicionar na lista..
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("ordenar")]
        public HttpResponseMessage Ordenar(OrdenarEnumModel modelAtributo)
        {
            try
            {                
                List<LivroConsultarModel> lista = new List<LivroConsultarModel>();

                foreach (Livro l in negocio.Ordenar(modelAtributo.ToString()))
                {
                    LivroConsultarModel model = new LivroConsultarModel();

                    model.ISBN = l.ISBN;
                    model.Autor = l.Autor;
                    model.Nome = l.Nome;
                    model.Preco = l.Preco;
                    model.DtPublicacao = Convert.ToDateTime(l.DtPublicacao);
                    model.DescImagemCapa = l.DescImagemCapa;
                    model.ImagemCapa = l.ImagemCapa;

                    lista.Add(model); 
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
