using BusinessLayer.AppEntities;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using GalleryMoqDataTest.TestEntities;
using System;
using System.Linq;
using Xunit;

namespace GalleryMoqDataTest.Repositories
{

    [Collection("PagedList")]
    public class RepositoryGetTests : IDisposable
    {
        public RepositoryGetTests(SqlLiteWith20EntitiesTestFixture fixture)
        {
            _testFixture = fixture;
        }

        public void Dispose()
        {
            _testFixture?.Dispose();
        }

        private readonly SqlLiteWith20EntitiesTestFixture _testFixture;

        #region User
        [Fact]
        public void GetList_User_ShouldGetPagedList()
        {
            using (var uow = new UnitOfWork<Gallery_dbContext>(_testFixture.Context))
            {
                var users = uow.GetRepository<Users,UserEntity>().GetList(size: 5);

                Assert.IsAssignableFrom<Paginate<UserEntity>>(users);

                Assert.Equal(20, users.Count);
                Assert.Equal(4, users.Pages);
                Assert.Equal(5, users.Items.Count);
            }
        }

        [Fact]
        public void GetList_User_ShouldGetPagedListUsingPredicate()
        {
            //Arrange 
            using (var uow = new UnitOfWork<Gallery_dbContext>(_testFixture.Context))
            {
                var repo = uow.GetRepository<Users, UserEntity>();
                //Act
                var userList = repo.GetList(predicate:
                                             x => x.IdRole == 1).Items;
                //Assert
                Assert.Equal(1, userList.Count);
            }
        }

        [Fact]
        public void GetList_User_ShouldGetPagedListUsingMultiPredicate()
        {
            //Arrange 
            using (var uow = new UnitOfWork<Gallery_dbContext>(_testFixture.Context))
            {
                var repo = uow.GetRepository<Users, UserEntity>();
                //Act
                var userListAdminRole = repo.GetList(predicate:
                                             x => x.IdRole == 1 &&
                                             x.Name.Equals("Mery") &&
                                             x.ProfilePictName.Equals("mery_pict")).Items;
                var userListRegularUserRole = repo.GetList(predicate:
                             x => x.IdRole == 3).Items;
                //Assert
                Assert.Equal(1, userListAdminRole.Count);
                Assert.Equal(10, userListRegularUserRole.Count);
            }
        }

        [Fact]
        public void GetList_User_ShouldGetAllUsersFromSqlQuerySelect()
        {
            // Arrange
            var strSQL = "Select * from Users";
            using (var uow = new UnitOfWork<Gallery_dbContext>(_testFixture.Context))
            {
                var repo = uow.GetRepository<Users, UserEntity>();
                //Act
                var productList = repo.Query(strSQL).AsEnumerable();
                //Assert
                Assert.Equal(20, productList.Count());
            }
        }


        [Fact]
        public void ShouldBeReadOnlyInterface()
        {
            // Arrange 
            using (var uow = new UnitOfWork<Gallery_dbContext>(_testFixture.Context))
            {
                //Act
                var repo = uow.GetReadOnlyRepository<Users>();
                //Assert
                Assert.IsAssignableFrom<IRepositoryReadOnly<Users>>(repo);
            }
        }

        [Fact]
        public void ShouldReadFromProducts()
        {
            // Arrange 
            using (var uow = new UnitOfWork<Gallery_dbContext>(_testFixture.Context))
            {
                var repo = uow.GetReadOnlyRepository<Users>();
                //Act 
                var products = repo.GetList().Items;
                //Assert
                Assert.Equal(20, products.Count);
            }
        }
        #endregion 


        //[Fact]
        //public void ShouldGetSqlQuerySelect()
        //{
        //    //Arrange
        //    var strSQL = "Select p.* from TestProduct p inner join TestCategory c on p.categoryid = c.id where c.id = 1";
        //    using (var uow = new UnitOfWork<Gallery_dbContext>(_testFixture.Context))
        //    {
        //        var repo = uow.GetRepository<TestProduct>();
        //        //Act
        //        var productList = repo.Query(strSQL).AsEnumerable();
        //        //Assert
        //        Assert.Equal(5, productList.Count());
        //    }
        //}




    }
}
