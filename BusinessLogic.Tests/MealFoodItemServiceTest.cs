using System;
using System.Dynamic;
using BusinessLogic.Services;
using BusinessLogic.Services.BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class MealFoodItemServiceTest
    {
        private readonly MealFoodItemService service;
        private readonly Mock<IMealFoodItemRepository> userRepositoryMoq;
        public MealFoodItemServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IMealFoodItemRepository>();

            repositoryWrapperMoq.Setup(x => x.MealFoodItem)
                .Returns(userRepositoryMoq.Object); 

            service = new MealFoodItemService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new MealFoodItem() { MealId = 0, FoodItemId = 0, ServingSize = 0} },
                new object[] { new MealFoodItem() { MealId = 1, FoodItemId = 0, ServingSize = 0 } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<MealFoodItem>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(MealFoodItem user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<MealFoodItem>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new MealFoodItem()
            {
                MealId = 1,
                FoodItemId = 1,
                ServingSize = (decimal)100.00,
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<MealFoodItem>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
