using Microsoft.EntityFrameworkCore;
using Quickorders.Domain.Entities;
using Quickorders.Domain.IRepository;
using Quickorders.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Infrastructure.Repositories
{
    class RestaurantRepository : IRestaurantRepository
    {
        private readonly DataContext _context;

        public RestaurantRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<DatabaseResponse<int>> AddMenu(Menu menu)
        {
           
            try
            {
                _context.Menus.Add(menu);
                await _context.SaveChangesAsync();
                
                return DatabaseResponse<int>.SuccessQuery(1); ;
            }
            catch(Exception e)
            {
                return DatabaseResponse<int>.ErrorQuery(e.Message, e);
            }
        }

        public async Task<Restaurant> GetByNit(int nit)
        {
            return await _context
                     .Restaurants
                     .Where(restaurant => restaurant.Nit == nit).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetByOwnerId(string ownerId)
        {
            return await _context.Restaurants
                .Where(restaurant => restaurant.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task<DatabaseResponse<string>> Insert(Restaurant restaurant)
        {
            DatabaseResponse<string> response ;
            try
            {
                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();
                response = DatabaseResponse<string>.SuccessQuery("Datos desde el repositorio de Restaurantes");
            }
            catch (Exception e)
            {
                response = DatabaseResponse<string>.ErrorQuery("Error inserting a restaurant", e);
            }

            return response;
        }
    }
}
