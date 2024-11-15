using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IActivityService
    {
        Task<List<Activity>> GetAll();
        Task<Activity> GetById(int id);
        Task Create(Activity model);
        Task Update(Activity model);
        Task Delete(int id);
    }
}
