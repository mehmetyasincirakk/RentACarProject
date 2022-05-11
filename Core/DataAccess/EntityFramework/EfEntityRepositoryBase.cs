
using Core.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext rentACarContext = new())
            {
                var addedEntity = rentACarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                rentACarContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext rentACarContext = new())
            {
                var deletedEntity = rentACarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rentACarContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext rentACarContext = new())
            {
                return rentACarContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext rentACarContext = new())
            {
                return filter == null ? rentACarContext.Set<TEntity>().ToList()
                    : rentACarContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext rentACarContext = new())
            {
                var updatedEntity = rentACarContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                rentACarContext.SaveChanges();
            }
        }
    }
}
