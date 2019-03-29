using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryMoqDataTest.Helpers
{
    public interface IDataAccessEntitiesGenerator<TEntity>
    {
        List<TEntity> GetTestItemsList(int size);
        TEntity GetTestItem();
    }
}
