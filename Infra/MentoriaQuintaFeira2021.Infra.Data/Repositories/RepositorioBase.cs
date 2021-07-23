using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Infra.Data.EF;
using System.Collections.Generic;
using System.Linq;

namespace MentoriaQuintaFeira2021.Infra.Data.Repositories
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly EFContext context;

        public RepositorioBase(EFContext context)
        {
            this.context = context;
        }

        public virtual TEntity Alterar(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return entity;
        }

        public virtual void Excluir(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity Incluir(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);            
            return entity;
        }

        public virtual TEntity Obter(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual List<TEntity> Obter()
        {
            return context.Set<TEntity>().ToList();
        }
    }
}
