using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DAL.Interfaces
{
    interface IBaseEntityDAL<TDAL, TBLL> where TDAL : class where TBLL : class
    {
        IPaginate<TDAL> Select();
        void Add(TBLL entity);
        void Delete(TBLL entity);
    }
}
