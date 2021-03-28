using Garage3._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Services
{
    public class MemberSelectService : IMemberSelectService
    {
        private readonly Garage3_0Context db;

        public MemberSelectService(Garage3_0Context db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<SelectListItem>> GetMemberAsync()
        {
            return await db.Members
                          .Select(v => v.Id)
                          .Distinct()
                          .Select(t => new SelectListItem
                          {
                              Text = t.ToString(),
                              Value = t.ToString()
                          })
                          .ToListAsync();
        }
    }
}
