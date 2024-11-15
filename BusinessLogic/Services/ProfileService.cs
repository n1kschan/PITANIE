using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ProfileService : IProfileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProfileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Profile>> GetAll()
        {
            return await _repositoryWrapper.Profile.FindAll();
        }

        public async Task<Profile> GetById(int id)
        {
            var Profile = await _repositoryWrapper.Profile
                .FindByCondition(x => x.ProfileId == id);
            return Profile.First();
        }

        public async Task Create(Profile model)
        {
            await _repositoryWrapper.Profile.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Profile model)
        {
            await _repositoryWrapper.Profile.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Profile = await _repositoryWrapper.Profile
                .FindByCondition(x => x.ProfileId == id);

            await _repositoryWrapper.Profile.Delete(Profile.First());
            await _repositoryWrapper.Save();
        }
    }
}