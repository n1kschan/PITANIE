using System;
using System.Dynamic;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class FoodAllergenServiceTest
    {
        private readonly FoodAllergenService service;
        private readonly Mock<IFoodAllergenRepository> userRepositoryMoq;
        public FoodAllergenServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IFoodAllergenRepository>();

            repositoryWrapperMoq.Setup(x => x.FoodAllergen)
                .Returns(userRepositoryMoq.Object); 

            service = new FoodAllergenService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new FoodAllergen() { FoodItemId = 0, AllergenId = 0, } },
                new object[] { new FoodAllergen() { FoodItemId = 1, AllergenId = 0, } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullFoodAllergen_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodAllergen>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewFoodAllergenShouldNotCreateNewUser(FoodAllergen user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodAllergen>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewFoodAllergenShouldCreateNewUser()
        {
            var newUser = new FoodAllergen()
            {
                FoodItemId = 1,
                AllergenId = 1,
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<FoodAllergen>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
