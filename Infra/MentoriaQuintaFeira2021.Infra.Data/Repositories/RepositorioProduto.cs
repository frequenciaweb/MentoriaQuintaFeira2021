using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Infra.Data.EF;
using MentoriaQuintaFeira2021.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
