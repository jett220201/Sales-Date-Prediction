using SalesDatePrediction_Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction_Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
