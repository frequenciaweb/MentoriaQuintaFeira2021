using MentoriaQuintaFeira2021.Domain.Entities;

namespace MentoriaQuintaFeira2021.Domain.Contracts.Services
{
    public interface IServicoProduto : IServicoBase<Produto>    
    {
        void MonitoramentoDoEstoque(int produtoID); 
    }    
}
