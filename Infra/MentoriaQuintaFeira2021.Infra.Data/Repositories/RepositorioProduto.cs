using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Infra.Data.EF;
using MentoriaQuintaFeira2021.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentoriaQuintaFeira2021.Domain.Filters;

namespace MentoriaQuintaFeira2021.Infra.Data.Repositories
{
    public class RepositorioProduto : RepositorioBase<Produto>, IRepositorioProduto
    {
        private EFContext Context { get; set; }

        public RepositorioProduto(EFContext context) : base(context)
        {
            Context = context;
        }

        public void ReduzirQuantidadeEmEstoque(int produtoid, int quantidade)
        {
            var produto = Context.Produtos.FirstOrDefault(x => x.ID == produtoid);
            produto.Quantidade -= quantidade;
            Context.Produtos.Update(produto);
        }

        public void AumentarQuantidadeEmEstoque(int produtoid, int quantidade)
        {
            var produto = Context.Produtos.FirstOrDefault(x => x.ID == produtoid);
            produto.Quantidade += quantidade;
            Context.Produtos.Update(produto);
        }

        public List<Produto> ListaProdutosDisponiveis()
        {
            return Context.Produtos
                .ToList()
                .Where(x => x.Disponivel)
                .ToList();
        }

        public List<Produto> ListarProdutosComFiltro(FiltroProdutos filtros)
        {
            IQueryable<Produto> query = Context.Produtos.AsQueryable();//Preparando a query

            for (int i = 0; i < filtros.Tipos.Count; i++)
            {
                int filtro = filtros.Tipos[i];
                string valor = filtros.Valores[i];

                if (filtro == 1)//Pesquisar por descrição
                {
                    query = query.Where(x => x.Descricao.Contains(valor));
                    continue;
                }

                if (filtro == 2)//Pesquisar por preço
                {
                    query = query.Where(x => x.Valor == decimal.Parse(valor));
                    continue;
                }

                if (filtro == 3)//Pesquisar por categoria
                {
                    query = query.Where(x => x.Categoria == valor);
                    continue;
                }

                if (filtro == 4)//Pesquisar por quantidade
                {
                    query = query.Where(x => x.Quantidade == int.Parse(valor));
                    continue;
                }
            }
            return query.ToList();
        }
    }
}
