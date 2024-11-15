using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserPreferenceService : IUserPreferenceService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserPreferenceService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserPreference>> GetAll()
        {
            return await _repositoryWrapper.UserPreference.FindAll();
        }

        public async Task<UserPreference> GetById(int id)
        {
            var UserPreference = await _repositoryWrapper.UserPreference
                .FindByCondition(x => x.UserPreferenceId == id);
            return UserPreference.First();
        }

        public async Task Create(UserPreference model)
        {
            await _repositoryWrapper.UserPreference.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(UserPreference model)
        {
            await _repositoryWrapper.UserPreference.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var UserPreference = await _repositoryWrapper.UserPreference
                .FindByCondition(x => x.UserPreferenceId == id);

            await _repositoryWrapper.UserPreference.Delete(UserPreference.First());
            await _repositoryWrapper.Save();
        }
    }
}