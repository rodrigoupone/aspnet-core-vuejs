using Infraestrutucture.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutucture.DataAccess
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        public AcaiContext Context { get; set; }

        public GenericDataRepository(AcaiContext diarioContext)
        {
            Context = diarioContext;
        }


        public async Task<T> BuscarPorId(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Buscar(Expression<Func<T, bool>> includeProperties, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = Context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            var obj = await dbQuery.AsNoTracking().Where(includeProperties).FirstOrDefaultAsync<T>();
            return obj;
        }

        public async Task<int> Count(Expression<Func<T, bool>> includeProperties)
        {
            IQueryable<T> dbQuery = Context.Set<T>();
            return await dbQuery.AsNoTracking().CountAsync(includeProperties);
        }

        public virtual async Task<IList<T>> BuscarItems()
        {
            List<T> list;
            IQueryable<T> dbQuery = Context.Set<T>();
            list = await dbQuery.AsNoTracking().ToListAsync<T>();
            return list;
        }

        public virtual async Task<IList<T>> GetItems(Expression<Func<T, bool>> includeProperties)
        {
            List<T> list;
            IQueryable<T> dbQuery = Context.Set<T>();
            list = await dbQuery.AsNoTracking().Where(includeProperties).ToListAsync<T>();
            return list;
        }

        public virtual bool IsExists(Expression<Func<T, bool>> includeProperties)
        {
            IQueryable<T> dbQuery = Context.Set<T>();
            return dbQuery.AsNoTracking().Any(includeProperties);
        }

        public virtual async Task<IList<T>> GetItems(Expression<Func<T, bool>> includeProperties, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            IQueryable<T> dbQuery = Context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);


            list = await dbQuery.AsNoTracking().Where(includeProperties).ToListAsync<T>();
            return list;
        }


        public async virtual Task Adicionar(T item)
        {
            Context.Entry(item).State = EntityState.Added;
            await Save();
        }

        public async virtual Task Atualizar(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            await Save();
        }

        public virtual async Task Remover(T item)
        {
            Context.Entry(item).State = EntityState.Deleted;
            await Save();
        }

        public virtual async Task Remove(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Context.Entry(item).State = EntityState.Deleted;
            }
            await Save();
        }


        public virtual async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
