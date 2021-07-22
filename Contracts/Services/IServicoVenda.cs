using MentoriaQuintaFeira2021.Entities;

namespace MentoriaQuintaFeira2021.Contracts.Services
{
    public interface IServicoVenda : IServicoBase<Venda>
    {
        bool EfetuarVenda(int produtoID, int clienteID, int quantidade, out string erro);
        void CancelarVenda(int id);
    }
}
