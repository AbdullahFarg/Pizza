using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.Iterfaces
{
    public interface IRepository<T>where T : class
    {
        Task<IEnumerable<T>> GetAllAsync ();

        Task<T?> GetById (int id);   

        Task AddAsync (T entity);

        void Update (int id , T entity);

        void Delete (T entity);

        Task SaveChangesAsync ();


    }
}
