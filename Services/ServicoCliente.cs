using MentoriaQuintaFeira2021.Contracts.Repositories;
using MentoriaQuintaFeira2021.Contracts.Services;
using MentoriaQuintaFeira2021.EF;
using MentoriaQuintaFeira2021.Entities;

namespace MentoriaQuintaFeira2021.Services
{
    public class ServicoCliente : ServicoBase<Cliente>, IServicoCliente 
    {
        public ServicoCliente(IRepositorioCliente repo, EFContext context) : base(repo, context)
        {

        }
    }
}
