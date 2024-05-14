using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProgramApplication;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
        protected readonly Context _context;

        /// <summary>
        /// Constructor, This Constructor Sub-Method Parent Constructor To
        /// Initialize Application DbContext
        /// Also This Generic Method, Extends The Basic CRUD Stubs To Other Repository
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        ///  SaveAsync Method For Saving Type T where : BaseEntity
        /// </summary>
        protected async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Save Method For Entity
        /// </summary>
        protected async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Abstraction Method To Give Count Of Entitys
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        /// <summary>
        /// Method To Create Record
        /// </summary>
        /// <param name="entity"></param>
        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        /// <summary>
        /// Method To Create Record And Return At The Same Time
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> CreateAndReturn(T entity)
        {
            await Create(entity);

            return entity;
        }

        /// <summary>
        /// This Method Deletes Entity 'T'
        /// </summary>
        /// <param name="entity"></param>
        public async Task Delete(T entity)
        {
            _context.Remove(entity);

            await SaveAsync();
        }

        /// <summary>
        /// Find Entity By Argument Predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        /// <summary>
        /// Get All  Values For Entity
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Get All  Values For Entity as a query
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Get Entity By Its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Get Entity By Its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Convert To List<T>
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> ToList()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Update Entity Object
        /// </summary>
        /// <param name="entity"></param>
        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await SaveAsync();

            return entity;
        }

        /// <summary>
        /// Create Multiple
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<List<T>> CreateMultiple(List<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            await SaveAsync();
            return entity;
        }

        /// <summary>
        ///  begins a transaction
        /// </summary>
        /// <returns></returns>
        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// returns true if any entity exists
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns> 
        public async Task<bool> Any(Func<T, bool> value)
        {
            return  _context.Set<T>().Any(value);
        }
    }
