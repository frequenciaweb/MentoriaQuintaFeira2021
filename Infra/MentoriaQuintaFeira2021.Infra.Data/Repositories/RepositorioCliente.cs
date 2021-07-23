using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Infra.Data.EF;
using MentoriaQuintaFeira2021.Domain.Entities;

namespace MentoriaQuintaFeira2021.Infra.Data.Repositories
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        private EFContext Context { get; set; }

        public RepositorioCliente(EFContext context) : base(context)
        {
            Context = context;
        }
    }
}
