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
    class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<DatabaseResponse<string>> Insert(Owner owner)
        {
            DatabaseResponse<string> response;
            try
            {
                _context.Owner.Add(owner);
                await _context.SaveChangesAsync();
                response = DatabaseResponse<string>.SuccessQuery("Owner Inserted");
            }
            catch (Exception e)
            {
                response = DatabaseResponse<string>.ErrorQuery("Error Inserting owner", e);
            }

            return response;
        }
    }
}
