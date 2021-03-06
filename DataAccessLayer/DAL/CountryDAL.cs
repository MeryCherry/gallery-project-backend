﻿using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class CountryDAL : BaseEntityDAL<Country, CountryEntity>
    {

        public CountryDAL(IOptions<AppSettingsModel> settings) : base(settings) { }
    }
}
