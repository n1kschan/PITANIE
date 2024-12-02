using System;
using System.Dynamic;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class RecordServiceTest
    {
        private readonly RecordService service;
        private readonly Mock<IRecordRepository> userRepositoryMoq;
        public RecordServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IRecordRepository>();

            repositoryWrapperMoq.Setup(x => x.Record)
                .Returns(userRepositoryMoq.Object); 

            service = new RecordService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new Domain.Models.Record() { UserId = 0, ActivityId = 0, RecordDate = DateTime.MaxValue } },
                new object[] { new Domain.Models.Record() { UserId = 1, ActivityId = 1, RecordDate = DateTime.MaxValue } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Domain.Models.Record>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(Domain.Models.Record user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Domain.Models.Record>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new Domain.Models.Record()
            {
                UserId = 1,
                ActivityId = 1,
                RecordDate = DateTime.Now,
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Domain.Models.Record>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
