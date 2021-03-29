using Garage3._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Services
{
    public class TypeSelectService : ITypeSelectService
    {
        private readonly Garage3_0Context db;
        public TypeSelectService(Garage3_0Context db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypeAsync()
        {
            return await db.VehicleTypes

                         
                          .Select(t => new SelectListItem
                          {
                              Text = t.TypeName.ToString(),
                              Value = t.Id.ToString()
                          }).Distinct()
                          .ToListAsync();
        }
    }
}
