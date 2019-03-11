using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DAL
{
   

    public class BaseEntityDAL
    {
        private readonly Gallery_dbContext _context;

        public BaseEntityDAL(Gallery_dbContext context, IConfiguration configuration)
        {
            _context = context;
        }
    }
}
