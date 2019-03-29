using AutoFixture.Xunit2;
using BusinessLayer.AppEntities;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using GalleryMoqDataTest.TestEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace GalleryMoqDataTest.Repositories
{
    public class RepositoryAddTest : IClassFixture<InMemoryTestFixture>
    {

        public RepositoryAddTest(InMemoryTestFixture fixture)
        {
            _fixture = fixture;
        }

        private readonly InMemoryTestFixture _fixture;


        #region user

        [Theory]
        [AutoData]
        public async void Add_ShouldCreateUser(UserEntity expected)
        {
            expected.IdRoleNavigation = null;
            var actual = await AddEntity<Users, UserEntity>( expected);

            //Assert
            
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.IdRole, actual.IdRole);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Password, actual.Password);
            Assert.Equal(expected.ProfilePictName, actual.ProfilePictName);
        }

        #endregion


        private async Task<TDAL> AddEntity<TDAL,TBLL>(TBLL expected) where TDAL : class
                                                               where TBLL : class
        {
            TDAL result;
            using (var uow = new UnitOfWork<Gallery_dbContext>(_fixture.Context))
            {
                //arrange
                var repo = uow.GetRepository<TDAL, TBLL>();

                //act
                repo.Add(expected);
                uow.SaveChanges();


                var list = await uow.Context.Set<TDAL>().ToListAsync();
                result = list?.Count > 0 ? list[0] : default(TDAL);
            }

            return result;
        }

    }
}
