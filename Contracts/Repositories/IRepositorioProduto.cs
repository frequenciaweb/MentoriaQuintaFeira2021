using MentoriaQuintaFeira2021.Entities;
using System.Collections;
using System.Collections.Generic;

namespace MentoriaQuintaFeira2021.Contracts.Repositories
{
    public interface IRepositorioProduto : IRepositorioBase<Produto>
    {
        void ReduzirQuantidadeEmEstoque(int produtoid, int quantidade);
        void AumentarQuantidadeEmEstoque(int produtoid, int quantidade);
        List<Produto> ListaProdutosDisponiveis();
    }
}
