using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garage3._0.Services
{
    public interface IMemberSelectService
    {
        Task<IEnumerable<SelectListItem>> GetMemberAsync();
    }
}