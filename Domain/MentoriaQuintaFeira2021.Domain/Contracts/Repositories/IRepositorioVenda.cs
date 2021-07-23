using MentoriaQuintaFeira2021.Domain.Entities;
using System.Collections.Generic;

namespace MentoriaQuintaFeira2021.Domain.Contracts.Repositories
{
    public interface IRepositorioVenda : IRepositorioBase<Venda>
    {
        void CancelarVenda(int id);
        void FecharVenda(Venda venda);        
    }
}
