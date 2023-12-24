using JITCATALOG.APPLICATION.Contracts;
using JITCATALOG.INFRASTRUCTURE.DB;
using Microsoft.EntityFrameworkCore;


namespace JITCATALOG.INFRASTRUCTURE.Repositories;

public class BaseClass<T> : IBaseRepository<T> where T : class
{
    #region Properties
    protected readonly AppDbContext _appDbContext;
    protected readonly DbSet<T> _entitySet;
    #endregion

    #region Constructor
    public BaseClass(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _entitySet = _appDbContext.Set<T>();
    }
    #endregion

    #region Methods
    public async Task<T> Add(T entity)
    {
        var addedEntity = _entitySet.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return addedEntity.Entity;
    }

    public async Task AddRange(List<T> entities)
    {
        _entitySet.AddRange(entities);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _entitySet.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _entitySet.FindAsync(id);
        
    }

    public async Task<bool> IsExists(string key, int value)
    {
        return await _entitySet.AnyAsync(e => EF.Property<int>(e, key) == value);
    }

    public async Task<bool> IsExistsForUpdate(int id, string key, string value)
    {
        return await _entitySet.AnyAsync(e => EF.Property<string>(e, key) == value && EF.Property<int>(e, "Id") != id);
    }


    public async Task Remove(T entity)
    {
        _entitySet.Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _entitySet.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    #endregion
}
