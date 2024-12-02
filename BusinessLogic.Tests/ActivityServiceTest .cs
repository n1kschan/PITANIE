using System;
using System.Dynamic;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class ActivityServiceTest
    {
        private readonly ActivityService service;
        private readonly Mock<IActivityRepository> userRepositoryMoq;
        public ActivityServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IActivityRepository>();

            repositoryWrapperMoq.Setup(x => x.Activity)
                .Returns(userRepositoryMoq.Object); 

            service = new ActivityService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new Activity() { UserId = 0, ActivityName = "", CaloriesBurned = 0, Duration = 0 } },
                new object[] { new Activity() { UserId = 1, ActivityName = "", CaloriesBurned = 0,  Duration = 0 } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullActivity_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Activity>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewActivityShouldNotCreateNewUser(Activity user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Activity>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewActivityShouldCreateNewUser()
        {
            var newUser = new Activity()
            {
                UserId = 1,
                ActivityName = "Running",
                CaloriesBurned = 300,
                Duration = 30,
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Activity>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
