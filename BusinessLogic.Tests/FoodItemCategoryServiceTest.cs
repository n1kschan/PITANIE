using System;
using System.Dynamic;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class FoodItemCategoryServiceTest
    {
        private readonly FoodItemCategoryService service;
        private readonly Mock<IFoodItemCategoryRepository> userRepositoryMoq;
        public FoodItemCategoryServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IFoodItemCategoryRepository>();

            repositoryWrapperMoq.Setup(x => x.FoodItemCategory)
                .Returns(userRepositoryMoq.Object); 

            service = new FoodItemCategoryService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new FoodItemCategory() {FoodItemId = 0, FoodCategoryId = 0, } },
                new object[] { new FoodItemCategory() {FoodItemId = 1, FoodCategoryId = 0,} },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodItemCategory>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(FoodItemCategory user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodItemCategory>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new FoodItemCategory()
            {
                FoodItemId = 1,
                FoodCategoryId = 1,
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodItemCategory>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
