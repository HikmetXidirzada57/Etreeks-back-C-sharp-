using Core.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.Entityframework
{
    public class EfEntityRepoBase<TContext, TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext:IdentityDbContext, new()
    {
        public void Add(TEntity entity)
        {
            using TContext context = new();

            var myEntity= context.Entry(entity);
            myEntity.State= EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new();

            var myEntity = context.Entry(entity);
            myEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter)
        {
            if(filter == null)
                return null;
         
          using TContext context=new();
          return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<TEntity>>? GetAll(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                return null;

            using TContext context = new();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new();

            var myEntity = context.Entry(entity);
            myEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
