using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : class
    {
        public RepositoryReadOnly(DbContext context) : base(context)
        {
        }
    }
}
