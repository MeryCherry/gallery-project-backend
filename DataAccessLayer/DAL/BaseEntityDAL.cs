using BusinessLayer.Configuration;
using DataAccessLayer.DAL.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{


    public class BaseEntityDAL<TDAL, TBLL>: IBaseEntityDAL<TDAL, TBLL> where TDAL: class where TBLL : class
    {
        private readonly Gallery_dbContext _context;

        public BaseEntityDAL(IOptions<AppSettingsModel> settings)
        {
            _context = new Gallery_dbContext(settings);
        }

        //TODO: it has to be paginate for business layer
        public IPaginate<TDAL> Select()
        {
            IPaginate<TDAL> result;
            using (var uow = new UnitOfWork<Gallery_dbContext>(_context))
            {
                result = uow.GetRepository<TDAL, TBLL>().GetList(size: 5);
               
               // res.Items =  Mapper.Map<TBLL[]>(res.Items);

            }
            return result;
        }

        public void Add(TBLL entity)
        {

            using (var uow = new UnitOfWork<Gallery_dbContext>(_context))
            {
                var repo = uow.GetRepository<TDAL, TBLL>();
                repo.Add(entity);
                uow.SaveChanges();


            }
        }

        public void Delete(TBLL entity)
        {

            using (var uow = new UnitOfWork<Gallery_dbContext>(_context))
            {
                var repo = uow.GetRepository<TDAL, TBLL>();
                repo.Delete(entity);
                uow.SaveChanges();
            }
        }
    }
}
