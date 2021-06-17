using Quickorders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.IRepository
{
    public interface IRestaurantRepository
    {
        Task<DatabaseResponse<string>> Insert(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetByOwnerId(string ownerId);
        Task<Restaurant> GetByNit(int nit);
        Task<DatabaseResponse<int>> AddMenu(Menu menu);
    }
}
