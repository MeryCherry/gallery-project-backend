using BusinessLayer.AppEntities;
using DataAccessLayer.DAL.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using FizzWare.NBuilder;
using System.Collections.Generic;
using System.Linq;

namespace GalleryWebAPITest.Helpers
{
    public class DataProviderFake<TBLL>: IBaseEntityDAL<TBLL> where TBLL : class, IBaseEntity
    {
        private readonly List<TBLL> _entityList;
        private DataAccessEntitiesGenerator<TBLL> _dataGenerator;

        public DataProviderFake(){
            _dataGenerator = new DataAccessEntitiesGenerator<TBLL>();
            _entityList = _dataGenerator.GetTestItemsList(20);
        }

        public IPaginate<TBLL> Select()
        {
            return _entityList.ToPaginate<TBLL>(index: 0, size: 5);
        }

        public TBLL Get(int id)
        {
            return _entityList.First(x=>x.Id == id);
        }

        public void Add(TBLL entity)
        {
            entity.Id = Builder<int>.CreateNew()
                .Build();
            _entityList.Add(entity);
        }

        public void Delete(TBLL entity)
        {
            _entityList.Remove(entity);
        }

        public void Delete(int id)
        {

            var existing = _entityList.First(a => a.Id == id);
            _entityList.Remove(existing);
        }

        public void Update(TBLL entity)
        {
            var existing = _entityList.First(a => a.Id == entity.Id);
            _entityList.Remove(existing);
            _entityList.Add(entity);
        }
    }
}
