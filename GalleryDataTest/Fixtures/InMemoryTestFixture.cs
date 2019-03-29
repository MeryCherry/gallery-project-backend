using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryMoqDataTest.TestEntities
{
    //using inMemoryProvider that is used for testing purposes
    public class InMemoryTestFixture : IDisposable
    {
        public Gallery_dbContext Context => InMemoryContext();

        public void Dispose()
        {
            Context?.Dispose();
        }

        private static Gallery_dbContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<Gallery_dbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var context = new Gallery_dbContext(options);

            return context;
        }
    }
}
