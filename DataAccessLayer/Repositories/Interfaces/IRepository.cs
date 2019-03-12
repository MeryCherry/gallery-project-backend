using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRepository<TDAL, TBLL> : IReadRepository<TDAL>, IDisposable where TDAL : class
    {
        void Add(TBLL entity);
        void Add(params TBLL[] entities);
        void Add(IEnumerable<TBLL> entities);


        void Delete(TBLL entity);
        void Delete(object id);
        void Delete(params TBLL[] entities);
        void Delete(IEnumerable<TBLL> entities);


        void Update(TBLL entity);
        void Update(params TBLL[] entities);
        void Update(IEnumerable<TBLL> entities);
    }
}
