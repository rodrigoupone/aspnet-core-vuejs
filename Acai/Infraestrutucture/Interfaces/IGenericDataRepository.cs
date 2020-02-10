using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutucture.Interfaces
{
    interface IGenericDataRepository<T> where T : class
    {
        Task<IList<T>> BuscarItems();
        Task<IList<T>> GetItems(Expression<Func<T, bool>> expressions);
        Task<IList<T>> GetItems(Expression<Func<T, bool>> expressions, params Expression<Func<T, object>>[] navigationProperties);
        Task Adicionar(T item);
        Task Atualizar(T item);
        Task Remover(T item);
    }
}
