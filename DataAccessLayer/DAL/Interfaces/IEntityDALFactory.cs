using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DAL.Interfaces
{
    public interface IEntityDALFactory
    {
        IBaseEntityDAL<TBLL> Get<TProvider, TBLL>() where TBLL : class
            where TProvider : IBaseEntityDAL<TBLL>;
    }
}
