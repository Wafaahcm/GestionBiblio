using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JITCATALOG.APPLICATION.Contracts;
using JITCATALOG.DOMAIN.Models;
using JITCATALOG.INFRASTRUCTURE.DB;
using Microsoft.EntityFrameworkCore;

namespace JITCATALOG.INFRASTRUCTURE.Repositories
{
    public class BookRepository : BaseClass<Livre>, IBookRepository
    {
        public BookRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Livre> GetByIdAsync(int id)
        {
            return await _entitySet.FindAsync(id);
        }

        public async Task<Livre> AddAsync(Livre entity)
        {
            var addedEntity = _entitySet.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task UpdateAsync(Livre entity)
        {
            _entitySet.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Livre entity)
        {
            _entitySet.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Livre>> GetAllBookAsync(bool includeRelatedEntities)
        {
            /*IQueryable<Livre> query = _entitySet;*/

            //if (includeRelatedEntities)
            //{
            //    query = query
            //        .Include(l => l.AuteurId) 
            //        .Include(l => l.EditeurId)
            //        .Include(l => l.GenreId);
            //}

            //return await query.ToListAsync();

            List<Livre> allBooks = new List<Livre>();
            allBooks = includeRelatedEntities ? await _entitySet.Include(x => x.EditeurId).ToListAsync() : await _entitySet.ToListAsync();
            return allBooks;
        }

        public async Task<Livre> GetBookByIdAsync(int id, bool includeRelatedEntities)
        {
            IQueryable<Livre> query = _entitySet;

            if (includeRelatedEntities)
            {
                query = query
                    .Include(l => l.Catalogues)
                    .Include(l => l.AuteurId)  
                    .Include(l => l.Editeur)
                    .Include(l => l.Genre)
                    .Include(l => l.Historiques);
            }

            return await query.SingleOrDefaultAsync(l => l.Id == id);
        }
    }
}
