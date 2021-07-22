using MentoriaQuintaFeira2021.Contracts.Repositories;
using MentoriaQuintaFeira2021.Contracts.Services;
using MentoriaQuintaFeira2021.EF;
using MentoriaQuintaFeira2021.Entities;
using System.Linq;

namespace MentoriaQuintaFeira2021.Services
{
    public class ServicoVenda : ServicoBase<Venda>, IServicoVenda
    {
        private EFContext Context { get; set; }
        private IRepositorioProduto RepositorioProduto { get; set; }
        private IRepositorioVenda RepositorioVenda { get; set; }

        public ServicoVenda(IRepositorioVenda repo, IRepositorioProduto repositorioProduto, IRepositorioVenda repositorioVenda, EFContext context) : base(repo, context)
        {
            Context = context;
            RepositorioProduto = repositorioProduto;
            RepositorioVenda = repositorioVenda;
        }

        public bool EfetuarVenda(int produtoID, int clienteID, int quantidade, out string erro)
        {
            erro = "";

            Produto produto = RepositorioProduto.Obter(produtoID);

            if (produto.Quantidade >= quantidade)
            {

                Venda venda = new Venda
                {
                    ProdutoID = produto.ID,
                    ClienteID = clienteID,
                    Data = System.DateTime.Now,
                    Valor = produto.Valor,
                    ValorTotal = produto.Valor * quantidade,
                    Quantidade = quantidade
                };

                produto.Quantidade -= quantidade;
                RepositorioProduto.Alterar(produto);
                RepositorioVenda.Incluir(venda);
                Commit();
                return true;
            }
            else
            {
                erro = "Quantidade indisponível por favor informe um número menor ou igual a " + produto.Quantidade;
            }

            return false;

        }

        public void CancelarVenda(int id)
        {
            var venda = Context.Vendas.FirstOrDefault(x => x.ID == id);
            RepositorioVenda.Excluir(venda);

            var produto = RepositorioProduto.Obter(venda.ProdutoID);
            produto.Quantidade += venda.Quantidade;

            RepositorioProduto.Alterar(produto);

            Commit();
        }
    }
}
