using System;
using System.Dynamic;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class FoodCategoryServiceTest
    {
        private readonly FoodCategoryService service;
        private readonly Mock<IFoodCategoryRepository> userRepositoryMoq;
        public FoodCategoryServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IFoodCategoryRepository>();

            repositoryWrapperMoq.Setup(x => x.FoodCategory)
                .Returns(userRepositoryMoq.Object); 

            service = new FoodCategoryService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new FoodCategory() { CategoryName = "", } },
                new object[] { new FoodCategory() { CategoryName = "Protein", } } 
            };
        }

        [Fact]
        public async Task CreateAsync_NullFoodCategory_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodCategory>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewFoodCategoryShouldNotCreateNewUser(FoodCategory user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodCategory>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewFoodCategoryShouldCreateNewUser()
        {
            var newUser = new FoodCategory()
            {
                CategoryName = "Protein",
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodCategory>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
