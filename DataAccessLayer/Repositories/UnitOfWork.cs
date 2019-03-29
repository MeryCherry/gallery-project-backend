using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork
           where TContext : DbContext, IDisposable
    {
        //list of all repositories, it controls that instance of repository with
        //SPECIFIC  type is created just once
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TDAL, TBLL> GetRepository<TDAL, TBLL>() where TDAL : class
                                                                   where TBLL : class
        {                                                          
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TDAL);
            //checks if repository with specific type already exists
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TDAL, TBLL>(Context);
            return (IRepository<TDAL, TBLL>)_repositories[type];
        }

        //public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        //{
        //    if (_repositories == null) _repositories = new Dictionary<Type, object>();

        //    var type = typeof(TEntity);
        //    if (!_repositories.ContainsKey(type)) _repositories[type] = new RepositoryAsync<TEntity>(Context);
        //    return (IRepositoryAsync<TEntity>)_repositories[type];
        //}

        public IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new RepositoryReadOnly<TEntity>(Context);
            return (IRepositoryReadOnly<TEntity>)_repositories[type];
        }
        //database context
        public TContext Context { get; }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
