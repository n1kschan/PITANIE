using System;
using System.Dynamic;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class UserPreferenceServiceTest
    {
        private readonly UserPreferenceService service;
        private readonly Mock<IUserPreferenceRepository> userRepositoryMoq;
        public UserPreferenceServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserPreferenceRepository>();

            repositoryWrapperMoq.Setup(x => x.UserPreference)
                .Returns(userRepositoryMoq.Object); 

            service = new UserPreferenceService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new UserPreference() { UserId = 0, PreferenceName = "", PreferenceValue = "" } },
                new object[] { new UserPreference() { UserId = 1, PreferenceName = "", PreferenceValue = "" } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<UserPreference>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(UserPreference user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<UserPreference>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new UserPreference()
            {
                UserId = 1,
                PreferenceName = "Test",
                PreferenceValue = "test@test.com",
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<UserPreference>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
