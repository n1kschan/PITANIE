using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProfileService
    {
        Task<List<Profile>> GetAll();
        Task<Profile> GetById(int id);
        Task Create(Profile model);
        Task Update(Profile model);
        Task Delete(int id);
    }
}
