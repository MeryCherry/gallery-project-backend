using AutoMapper;
using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.DAL.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{


    public class BaseEntityDAL<TDAL, TBLL>: IBaseEntityDAL<TBLL> where TDAL: class, IDataBaseEntity where TBLL : class, IBaseEntity
    {
        private readonly Gallery_dbContext _context;

        public BaseEntityDAL(IOptions<AppSettingsModel> settings)
        {
            _context = new Gallery_dbContext(settings);
        }

        /// <summary>
        /// Mapping method
        /// </summary>
        /// <typeparam name="Source">type of source of mapping</typeparam>
        /// <typeparam name="Destiny">type mapper creates map to</typeparam>
        /// <param name="obj">object to be mapped</param>
        /// <returns>mapped object</returns>
        protected virtual Destiny Map<Source, Destiny>(Source obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Source, Destiny>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Source, Destiny>(obj);
        }

        public IPaginate<TBLL> Select()
        {
            IPaginate<TBLL> result;
            using (var uow = new UnitOfWork<Gallery_dbContext>(_context))
            {
                var r = uow.GetRepository<TDAL, TBLL>().GetList(size: 5);

               result =  Map<IPaginate<TDAL>, Paginate<TBLL>>(r);

            }
            return result;
        }

        public TBLL Get(int id)
        {
            TBLL result;
            using (var uow = new UnitOfWork<Gallery_dbContext>(_context))
            {
                var r = uow.GetRepository<TDAL, TBLL>().GetList(predicate: en =>en.Id==id)?.Items;
                
                result = r.Count>0 ? Map<TDAL, TBLL>(r[0]): default(TBLL);

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

        public void Delete(int id)
        {

            using (var uow = new UnitOfWork<Gallery_dbContext>(_context))
            {
                var repo = uow.GetRepository<TDAL, TBLL>();
                repo.Delete(id);
                uow.SaveChanges();
            }
        }

        public void Update(TBLL entity)
        {

            using (var uow = new UnitOfWork<Gallery_dbContext>(_context))
            {
                var repo = uow.GetRepository<TDAL, TBLL>();
                repo.Update(entity);
                uow.SaveChanges();
            }
        }
    }
}

