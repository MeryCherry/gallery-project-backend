using FizzWare.NBuilder;
using GalleryWebAPITest.Helpers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GalleryWebAPITest.Helpers
{
    public class DataAccessEntitiesGenerator<TEntity> : IDataAccessEntitiesGenerator<TEntity>
    {
        //methods generating test data
        public List<TEntity> GetTestItemsList(int size)
        {
            return Builder<TEntity>.CreateListOfSize(size)
                .Build().ToList();
        }

        public TEntity GetTestItem()
        {
            return Builder<TEntity>.CreateNew()
                .Build();
        }
    }
}
