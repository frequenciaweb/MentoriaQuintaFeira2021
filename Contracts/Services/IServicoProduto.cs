using MentoriaQuintaFeira2021.Entities;

namespace MentoriaQuintaFeira2021.Contracts.Services
{
    public interface IServicoProduto : IServicoBase<Produto>    
    {
        void MonitoramentoDoEstoque(int produtoID); 
    }    
}
