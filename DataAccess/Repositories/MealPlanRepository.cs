using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Repositories
{
    public class MealPlanRepository : RepositoryBase<MealPlan>, IMealPlanRepository
    {
        public MealPlanRepository(практическая_работаContext repositoryContext)
            : base(repositoryContext) 
        {
        }
    }
}
