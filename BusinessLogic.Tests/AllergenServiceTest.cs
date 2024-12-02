using System;
using System.Dynamic;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class AllergenServiceTest
    {
        private readonly AllergenService service;
        private readonly Mock<IAllergenRepository> userRepositoryMoq;
        public AllergenServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IAllergenRepository>();

            repositoryWrapperMoq.Setup(x => x.Allergen)
                .Returns(userRepositoryMoq.Object); 

            service = new AllergenService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new Allergen() { AllergenName = "", Description = "",  } },
                new object[] { new Allergen() { AllergenName = "Peanuts", Description = "", } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullAllergen_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Allergen>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewAllergenShouldNotCreateNewUser(Allergen user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Allergen>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new Allergen()
            {
                AllergenName = "Peanuts",
                Description = "Common allergen found in various food products.",
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Allergen>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
