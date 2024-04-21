using Microsoft.EntityFrameworkCore;
using RH.Data.Contexto;
using RH.Domain.Entities;
using RH.Domain.Interfaces.Repository;

namespace RH.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly RhContext _context;

        public BaseRepository(RhContext context)
        {
            _context = context;
        }

        public virtual async Task Incluir(T entity)
        {
            entity.CreateAt = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Alterar(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> SelecionarPorId(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<T>> SelecionarTudo()
        {
            //throw new Exception("erro aqui");
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}