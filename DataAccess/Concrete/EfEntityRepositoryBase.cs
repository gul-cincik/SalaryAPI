using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfRepoBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly SalaryDbContext salaryDbContext;

        public EfRepoBase(SalaryDbContext authDbContext)
        {
            this.salaryDbContext = authDbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            var addedEntity = salaryDbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            await salaryDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            // No need to use 'using' with async, and use SaveChangesAsync
            var updatedEntity = salaryDbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await salaryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            // No need to use 'using' with async, and use SaveChangesAsync
            var deletedEntity = salaryDbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await salaryDbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            // No need to use 'using' with async
            return await salaryDbContext.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                    ? await salaryDbContext.Set<TEntity>().ToListAsync()
                    : await salaryDbContext.Set<TEntity>().Where(filter).ToListAsync();

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await salaryDbContext.Set<TEntity>().FindAsync(id);
        }


    }
}
