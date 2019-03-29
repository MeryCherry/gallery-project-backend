using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {

    }
}
