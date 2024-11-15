using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class MealPlanService : IMealPlanService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MealPlanService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MealPlan>> GetAll()
        {
            return await _repositoryWrapper.MealPlan.FindAll();
        }

        public async Task<MealPlan> GetById(int id)
        {
            var MealPlan = await _repositoryWrapper.MealPlan
                .FindByCondition(x => x.MealPlanId == id);
            return MealPlan.First();
        }

        public async Task Create(MealPlan model)
        {
            await _repositoryWrapper.MealPlan.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(MealPlan model)
        {
            await _repositoryWrapper.MealPlan.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var MealPlan = await _repositoryWrapper.MealPlan
                .FindByCondition(x => x.MealPlanId == id);

            await _repositoryWrapper.MealPlan.Delete(MealPlan.First());
            await _repositoryWrapper.Save();
        }
    }
}