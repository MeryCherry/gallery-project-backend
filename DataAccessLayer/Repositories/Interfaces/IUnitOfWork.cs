using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TDAL, TEntity> GetRepository<TDAL,TEntity>() where TEntity : class 
                                                                 where TDAL : class;
        //IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;
        IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : class;

        int SaveChanges();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
