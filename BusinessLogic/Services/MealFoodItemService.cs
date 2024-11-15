using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    namespace BusinessLogic.Services
    {
        public class MealFoodItemService : IMealFoodItemService
        {
            private IRepositoryWrapper _repositoryWrapper;

            public MealFoodItemService(IRepositoryWrapper repositoryWrapper)
            {
                _repositoryWrapper = repositoryWrapper;
            }

            public async Task<List<MealFoodItem>> GetAll()
            {
                return await _repositoryWrapper.MealFoodItem.FindAll();
            }

            public async Task<MealFoodItem> GetById(int id)
            {
                var MealFoodItem = await _repositoryWrapper.MealFoodItem
                    .FindByCondition(x => x.MealFoodItemId == id);
                return MealFoodItem.First();
            }

            public async Task Create(MealFoodItem model)
            {
                await _repositoryWrapper.MealFoodItem.Create(model);
                await _repositoryWrapper.Save();
            }

            public async Task Update(MealFoodItem model)
            {
                await _repositoryWrapper.MealFoodItem.Update(model);
                await _repositoryWrapper.Save();
            }

            public async Task Delete(int id)
            {
                var MealFoodItem = await _repositoryWrapper.MealFoodItem
                    .FindByCondition(x => x.MealFoodItemId == id);

                await _repositoryWrapper.MealFoodItem.Delete(MealFoodItem.First());
                await _repositoryWrapper.Save();
            }
        }
    }
}