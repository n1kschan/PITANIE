using System;
using System.Dynamic;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;


namespace BusinessLogic.Tests
{
    public class ShoppingListItemServiceTest
    {
        private readonly ShoppingListItemService service;
        private readonly Mock<IShoppingListItemRepository> userRepositoryMoq;
        public ShoppingListItemServiceTest() 
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IShoppingListItemRepository>();

            repositoryWrapperMoq.Setup(x => x.ShoppingListItem)
                .Returns(userRepositoryMoq.Object); 

            service = new ShoppingListItemService(repositoryWrapperMoq.Object);    
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new ShoppingListItem() { ShoppingListItemId = 0, ShoppingListId = 0, FoodItemId = 0, Quantity = 0 } },
                new object[] { new ShoppingListItem() { ShoppingListItemId = 1, ShoppingListId = 0, FoodItemId = 0, Quantity = 0 } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<ShoppingListItem>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(ShoppingListItem user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<ShoppingListItem>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new ShoppingListItem()
            {
                ShoppingListItemId = 1,
                ShoppingListId = 1,
                FoodItemId = 1,
                Quantity =(decimal)100.00,
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<ShoppingListItem>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);


        }
    }
}
