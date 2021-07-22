using MentoriaQuintaFeira2021.Entities;
using System.Collections.Generic;

namespace MentoriaQuintaFeira2021.Contracts.Repositories
{
    public interface IRepositorioVenda : IRepositorioBase<Venda>
    {
        void CancelarVenda(int id);
        void FecharVenda(Venda venda);        
    }
}
