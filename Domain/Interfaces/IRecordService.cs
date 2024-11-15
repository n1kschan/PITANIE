using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRecordService
    {
        Task<List<Record>> GetAll();
        Task<Record> GetById(int id);
        Task Create(Record model);
        Task Update(Record model);
        Task Delete(int id);
    }
}
