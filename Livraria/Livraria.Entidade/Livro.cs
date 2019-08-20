using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Entidade
{
    public class Livro
    {
        #region Atributos
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DtPublicacao { get; set; }
        public string ImagemCapa { get; set; }
        public string DescImagemCapa { get; set; }
        #endregion

        public Livro()
        {
            ISBN = "";
            Autor = "";
            Nome = "";
            Preco = 0;
            DtPublicacao = null;
            ImagemCapa = "";
        }

        public Livro(string iSBN, string autor, string nome, decimal preco, DateTime dtPublicacao, string descImagemCapa, string imagemCapa)
        {
            ISBN = iSBN;
            Autor = autor;
            Nome = nome;
            Preco = preco;
            DtPublicacao = dtPublicacao;
            ImagemCapa = imagemCapa;
            DescImagemCapa = descImagemCapa;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Autor: {Autor}, Nome: {Nome}, Preço: {Preco}, " +
                   $"Data de Publicação: {DtPublicacao}, Descrição Imagem da Capa: {DescImagemCapa}";
        }
    }
}
