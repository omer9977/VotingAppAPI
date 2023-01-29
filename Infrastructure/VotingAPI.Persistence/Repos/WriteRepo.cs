using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using VotingAPI.Domain.Entities.Common;
using VotingAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VotingAPI.Application.Exceptions;

namespace VotingAPI.Persistence.Repos
{
    public class WriteRepo<T> : IWriteRepo<T> where T : BaseEntity
    {
        readonly ElectionSystemDbContext dbContext;
        public WriteRepo(ElectionSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public DbSet<T> Table => dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            EntityEntry entityEntry = await Table.AddAsync(entity); // todo : buraya EntityEntry<T> entity böyle yazabilir miydik?
            if (entityEntry.State != EntityState.Added)
                throw new Exception();
            return (T)entityEntry.Entity;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry entityEntry = Table.Remove(entity);
            if (entityEntry.State != EntityState.Deleted)
                throw new Exception();
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            T entity = await Table.FirstOrDefaultAsync(x => id == x.Id);
            if (entity == null)
                throw new DataNotFoundException(id);
            return Remove(entity);
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }


        public bool Update(T model)
        {
            EntityEntry entity = Table.Update(model);
            return entity.State == EntityState.Modified;
        }

        public bool UpdateRange(List<T> entities)
        {
            throw new NotImplementedException();
        }
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new DbUpdateException();
            }
        }
    }
}
