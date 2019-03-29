using GalleryMoqDataTest.TestEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GalleryMoqDataTest.TestCollection
{
    [CollectionDefinition("PagedList")]
    public class PagedListCollection : ICollectionFixture<SqlLiteWith20EntitiesTestFixture>
    {
    }
}
