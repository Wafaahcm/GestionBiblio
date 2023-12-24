using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Contracts;

public interface IBaseRepository<T> where T : class
{
    #region Methods
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Add(T entity);
    Task AddRange(List<T> entities);
    Task Update(T entity);
    Task Remove(T entity);
    Task<bool> IsExists(string key, int value);
    Task<bool> IsExistsForUpdate(int id, string key, string value);
    #endregion
}
