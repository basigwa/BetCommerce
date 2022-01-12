using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BetCommerce.RepositoryMixin
{
    public class Repository
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
        public async Task UpdateAsync(string sql, object[] args = null)
        {
            if (args == null)
                await Context.Database.ExecuteSqlRawAsync(sql);
            else
                await Context.Database.ExecuteSqlRawAsync(sql, args);
        }

        public async Task<List<TEntity>> FindOptimisedAsync<TEntity>(string sql, object[] args = null) where TEntity : class
        {
            return args == null ? await Context.Set<TEntity>().FromSqlRaw(sql).AsNoTracking().ToListAsync()
                : await Context.Set<TEntity>().FromSqlRaw(sql, args).AsNoTracking().ToListAsync();
        }
       
        public async Task<TEntity> FirstOrDefaultOptimisedAsync<TEntity>(string sql, object[] args = null) where TEntity : class
        {
            return args == null ? await Context.Set<TEntity>().FromSqlRaw(sql).AsNoTracking().FirstOrDefaultAsync()
                : await Context.Set<TEntity>().FromSqlRaw(sql, args).AsNoTracking().FirstOrDefaultAsync();
        }
       
      
      
       
    }
}
