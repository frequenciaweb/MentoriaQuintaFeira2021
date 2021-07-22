using MentoriaQuintaFeira2021.Contracts.Repositories;
using MentoriaQuintaFeira2021.Contracts.Services;
using MentoriaQuintaFeira2021.EF;
using MentoriaQuintaFeira2021.Entities;
using MentoriaQuintaFeira2021.Integrations;

namespace MentoriaQuintaFeira2021.Services
{
    public class ServicoProduto : ServicoBase<Produto>, IServicoProduto
    {
        private IRepositorioProduto RepositorioProduto { get; set; }

        public ServicoProduto(IRepositorioProduto repo, EFContext context) : base(repo, context)
        {
            RepositorioProduto = repo;
        }

        public void MonitoramentoDoEstoque(int produtoID)
        {
            Produto produto = RepositorioProduto.Obter(produtoID);

            if (!produto.Disponivel)
            {
                RepositorioProduto.Alterar(produto);
                string mensagem = $"Produto {produto.Descricao} está em falta no estoque";

                Commit();

                SMTP.EnviarMensagem("administrador-do-sistema@sistema.com", mensagem, "PRODUTO INDISPONIVEL");
                SMS.EnviarMensagem("61999998888", mensagem);
                WhatsApp.EnviarMensagem("61999998888", mensagem);

            }


        }
    }
}
