using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Domain.Contracts.Services;
using MentoriaQuintaFeira2021.Infra.Data.EF;
using MentoriaQuintaFeira2021.Domain.Entities;

namespace MentoriaQuintaFeira2021.Domain.Services
{
    public class ServicoCliente : ServicoBase<Cliente>, IServicoCliente 
    {
        public ServicoCliente(IRepositorioCliente repo, EFContext context) : base(repo, context)
        {

        }
    }
}
