using Microsoft.EntityFrameworkCore.Storage;

namespace ProgramApplication;

public interface IBaseRepository<T> where T : class
{
    /// <summary>
    /// Get All Entity Type 'T'
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAll();

    /// <summary>
    /// Get All Entity Type 'T' as query
    /// </summary>
    /// <returns></returns>
    IQueryable<T> Query();

    /// <summary>
    /// Find Method Using Predicate
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> Find(Func<T, bool> predicate);

    /// <summary>
    /// Get Entity 'T' By Primary Key = Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetById(int id);

    /// <summary>
    /// Get Entity 'T' By Primary Key = Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetById(Guid id);

    /// <summary>
    /// Create Entity Type 'T'
    /// </summary>
    /// <param name="entity"></param>
    Task Create(T entity);

    /// <summary>
    /// Create Multiple Entity List<typeparamref name="T"/>
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<List<T>> CreateMultiple(List<T> entity);

    /// <summary>
    /// Create And Return Entity Type 'T'
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> CreateAndReturn(T entity);

    /// <summary>
    /// Update Entity Type 'T'
    /// </summary>
    /// <param name="entity"></param>
    Task<T> Update(T entity);

    /// <summary>
    /// Delete Entity Type 'T'
    /// </summary>
    /// <param name="entity"></param>
    Task Delete(T entity);

    /// <summary>
    /// Count Entities Type 'T'
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<int> Count(Func<T, bool> predicate);

    /// <summary>
    /// Convert Entity To List
    /// </summary>
    /// <returns></returns>
    Task<List<T>> ToList();

    /// <summary>
    ///  begins a transaction
    /// </summary>
    /// <returns></returns>
    Task<IDbContextTransaction> BeginTransaction();

    /// <summary>
    /// returns true if any entity exists
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns> 
    Task<bool> Any(Func<T, bool> value);
}

