using Bootstrap;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class CountryDAL
    {
        private readonly Gallery_dbContext _context;

        public CountryDAL(IOptions<AppSettingsModel> settings)
        {

            _context = new Gallery_dbContext(settings);
        }

        public IPaginate<Country> Select()
        {
            IPaginate< Country> result;
            using (var uow = new UnitOfWork<Gallery_dbContext>(_context))
            {
                result = uow.GetRepository<Country>().GetList(size: 5);
            }
            return result;
        }
    }
}
