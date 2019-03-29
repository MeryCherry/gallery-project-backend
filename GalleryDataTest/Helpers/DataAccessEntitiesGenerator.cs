using DataAccessLayer.Models;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalleryMoqDataTest.Helpers
{
    public class DataAccessEntitiesGenerator<TEntity>: IDataAccessEntitiesGenerator<TEntity>
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
