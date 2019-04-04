using BusinessLayer.AppEntities;
using DataAccessLayer.DAL.Interfaces;

namespace GalleryWebAPITest.Helpers
{
    public class EntityDALFactoryFake<TBLL> : IEntityDALFactory where TBLL : class, IBaseEntity
    {
        IBaseEntityDAL<TBLL> _provider;
        public EntityDALFactoryFake(IBaseEntityDAL<TBLL> provider)
        {
            _provider = provider;
        }

        public IBaseEntityDAL<TBLL> Get<TProvider, TBLL>() where TBLL : class, IBaseEntity
            where TProvider : IBaseEntityDAL<TBLL>
        {
            return (IBaseEntityDAL<TBLL>)_provider;
        }
    }
}
