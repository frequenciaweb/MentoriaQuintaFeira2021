using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Domain.Contracts.Services;
using MentoriaQuintaFeira2021.Infra.Data.EF;

namespace MentoriaQuintaFeira2021.Domain.Services
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> repositorioBase;
        private readonly EFContext context;
        public ServicoBase(IRepositorioBase<TEntity> repositorioBase, EFContext context)
        {
            this.context = context;
            this.repositorioBase = repositorioBase;
        }

        public virtual TEntity Alterar(TEntity entity)
        {
            entity = repositorioBase.Alterar(entity);
            Commit();
            return entity;
        }

        public virtual void Excluir(TEntity entity)
        {
            repositorioBase.Excluir(entity);
            Commit();
        }

        public virtual TEntity Incluir(TEntity entity)
        {
            entity = repositorioBase.Incluir(entity);
            Commit();
            return entity;
        }

        protected void Commit()
        {
            context.SaveChanges();
        }

    }
}
