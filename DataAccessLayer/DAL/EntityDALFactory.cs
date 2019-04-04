using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace DataAccessLayer.DAL
{
    public class EntityDALFactory: IEntityDALFactory
    {
        IOptions<AppSettingsModel> _settings;

        public EntityDALFactory(IOptions<AppSettingsModel> settings)
        {
            _settings = settings;
        }

        public IBaseEntityDAL<TBLL> Get<TProvider, TBLL>() where TBLL : class, IBaseEntity
            where TProvider : IBaseEntityDAL<TBLL>
        {
            return (TProvider)Activator.CreateInstance(typeof(TProvider), new object[] { _settings });
        }

    }
}
