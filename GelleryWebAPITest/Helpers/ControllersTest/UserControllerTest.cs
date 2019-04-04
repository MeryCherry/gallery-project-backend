using BusinessLayer.AppEntities;
using DataAccessLayer.DAL.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using GalleryRESTWebService.Controllers;
using GalleryWebAPITest.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GalleryWebAPITest.Helpers.ControllersTest
{
    public class UserControllerTest
    {

        UserController _controller;
        private IBaseEntityDAL<UserEntity> _service;
        private IEntityDALFactory _factory;

        private List<UserEntity> _list;

        private IDataAccessEntitiesGenerator<UserEntity> _dataGenerator;

        private IDataAccessEntitiesGenerator<UserEntity> DataGenerator
        {
            get
            {
                if (_dataGenerator == null)
                {
                    _dataGenerator = new DataAccessEntitiesGenerator<UserEntity>();
                }
                return _dataGenerator;
            }
        }
        public UserControllerTest()
        {
            _service = new DataProviderFake<UserEntity>();
            _factory = new EntityDALFactoryFake<UserEntity>(_service);
            _list = GetListOfUsers(_service);
            _controller = new UserController(_factory);
        }



        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<UserEntity>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        //the same but with usage of MOQ
        [Fact]
        public void Get_WhenCalled_ReturnsAllItemsMoq()
        {
            var factoryMoq = new Mock<IEntityDALFactory>();

            factoryMoq.Setup(foo => 
            foo.Get<IBaseEntityDAL<UserEntity>,UserEntity>()).Returns(_service);
            var controller = new UserController(factoryMoq.Object);
            // Act
            var okResult = _controller.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<UserEntity>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void GetByID_UnknownIDPassed_ReturnsNotFoundResult()
        {

            // Act
            var notFoundResult = _controller.GetById(0);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {

            // Arrange
            var searched = _list[0];
            // Act
            var okResult = _controller.GetById(searched.Id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testID = _list[1].Id;

            // Act
            var okResult = _controller.GetById(testID) as OkObjectResult;

            // Assert
            Assert.IsType<UserEntity>(okResult.Value);
            Assert.Equal(testID, (okResult.Value as UserEntity).Id);
            Assert.Equal(_list[1], (okResult.Value as UserEntity));
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            //generate new user
            var testUser = DataGenerator.GetTestItem();
            //set name for empty value
            testUser.Name = string.Empty;
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(testUser);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var testItem = DataGenerator.GetTestItem();

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = DataGenerator.GetTestItem();
            testItem.Name = "Gabi";
            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as UserEntity;

            // Assert
            Assert.IsType<UserEntity>(item);
            Assert.Equal("Gabi", item.Name);
        }

        [Fact]
        public void Remove_NotExistingIDPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            int notExistingID = 0;

            // Act
            var badResponse = _controller.Delete(notExistingID);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIDPassed_ReturnsOkResult()
        {
            // Arrange
            var existingID = _list[0].Id;

            // Act
            var okResponse = _controller.Delete(existingID);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingID = _list[0].Id;

            // Act
            var okResponse = _controller.Delete(existingID);

            // Assert
            Assert.Equal(19, _service.Select().Count);
        }

        #region helper methods

        private List<UserEntity> GetListOfUsers(IBaseEntityDAL<UserEntity> service)
        {
            var list = service.Select();
            return ConvertPaginateToList(list);
        }

        private List<UserEntity> ConvertPaginateToList(IPaginate<UserEntity> users)
        {
            int count = users.Count;
            UserEntity[] temp = new UserEntity[count];
            users.Items.CopyTo(temp, 0);
            return ConvertArrayToList(temp);
        }

        private List<UserEntity> ConvertArrayToList(UserEntity[] users)
        {
            List<UserEntity> list = new List<UserEntity>();
            if (users != null && users.Length > 0)
            {
                list.AddRange(users);
            }
            return list;
        }

        #endregion
    }
}
