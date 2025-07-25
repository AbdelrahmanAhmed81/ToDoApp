﻿using Microsoft.EntityFrameworkCore;
using ToDo.Application.Contracts.Repositories;
using ToDo.Domain.Common;
using ToDo.Presistance.Contexts;

namespace ToDo.Presistance.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntityIdentified
    {
        protected ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            int result = await _context.SaveChangesAsync();
            return result == 1;
        }
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            entity.LastModificationDate = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            int result = await _context.SaveChangesAsync();
            return result == 1;
        }
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            int result = await _context.SaveChangesAsync();
            return result == 1;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();

        }
        public virtual async Task<T> GetByIdAsync(Guid id, bool trackEntity = true)
        {
            if (trackEntity)
                return await _context.Set<T>().FindAsync(id);
            else
                return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.ID == id);
        }
    }
}
