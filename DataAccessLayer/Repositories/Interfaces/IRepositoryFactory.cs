using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TDAL, TBLL> GetRepository<TDAL, TBLL>() where TDAL : class
                                                            where TBLL: class;
        //IRepositoryAsync<T> GetRepositoryAsync<T>() where T : class;
        IRepositoryReadOnly<TDAL> GetReadOnlyRepository<TDAL>() where TDAL : class;
    }
}
