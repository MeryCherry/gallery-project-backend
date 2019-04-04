using System.Collections.Generic;

namespace GalleryWebAPITest.Helpers.Interfaces
{
    public interface IDataAccessEntitiesGenerator<TEntity>
    {
        List<TEntity> GetTestItemsList(int size);
        TEntity GetTestItem();
    }
}
