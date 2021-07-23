using MentoriaQuintaFeira2021.Domain.Entities;

namespace MentoriaQuintaFeira2021.Domain.Contracts.Services
{
    public interface IServicoVenda : IServicoBase<Venda>
    {
        bool EfetuarVenda(int produtoID, int clienteID, int quantidade, out string erro);
        void CancelarVenda(int id);
    }
}
