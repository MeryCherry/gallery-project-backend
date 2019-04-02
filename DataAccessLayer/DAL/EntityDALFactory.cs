using BusinessLayer.Configuration;
using DataAccessLayer.DAL.Interfaces;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DAL
{
    public class EntityDALFactory: IEntityDALFactory
    {
        IOptions<AppSettingsModel> _settings;

        public EntityDALFactory(IOptions<AppSettingsModel> settings)
        {
            _settings = settings;
        }

        public IBaseEntityDAL<TBLL> Get<TProvider, TBLL>() where TBLL : class
            where TProvider : IBaseEntityDAL<TBLL>
        {
            return (TProvider)Activator.CreateInstance(typeof(TProvider), new object[] { _settings });
        }

    }
}
