using Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Data
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        
        internal minhasTarefasContext _context { get; private set; }
        DbSet<TEntity> m_DbSet;

        public BaseRepository(minhasTarefasContext context)
        {
            _context = context;

            _context.Configuration.AutoDetectChangesEnabled = false;
            _context.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            _context.Configuration.LazyLoadingEnabled = false;
            _context.Configuration.UseDatabaseNullSemantics = false;
            _context.Configuration.ValidateOnSaveEnabled = false;

            m_DbSet = _context.Set<TEntity>();
        }
        public TEntity Find(params object[] key)
        {
            return m_DbSet.Find(key);
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return m_DbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_DbSet.Where(predicate);
            }
            return m_DbSet.AsEnumerable();
        }

        public void Insert(TEntity obj)
        {
            m_DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;                        
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            m_DbSet.Where(predicate).ToList()
                .ForEach(del => m_DbSet.Remove(del));
        }

        public int Count()
        {
            return m_DbSet.Count();
        }        
    }
}