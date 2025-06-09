using Microsoft.EntityFrameworkCore;
using Pizza.CORE.Iterfaces;
using Pizza.EF.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.EF.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

       


        public async Task AddAsync(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public  void Delete(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));
             _dbset.Remove(entity);
             _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Update(int id , T entity)
        {
            _dbset.Update(entity);
            _context.SaveChangesAsync();

        }
    }
}
