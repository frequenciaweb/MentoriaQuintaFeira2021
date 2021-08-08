using MentoriaQuintaFeira2021.Domain.Entities;
using MentoriaQuintaFeira2021.Domain.Filters;
using System.Collections;
using System.Collections.Generic;

namespace MentoriaQuintaFeira2021.Domain.Contracts.Repositories
{
    public interface IRepositorioProduto : IRepositorioBase<Produto>
    {
        void ReduzirQuantidadeEmEstoque(int produtoid, int quantidade);
        void AumentarQuantidadeEmEstoque(int produtoid, int quantidade);
        List<Produto> ListarProdutosComFiltro(FiltroProdutos filtro);
        List<Produto> ListaProdutosDisponiveis();
    }
}
