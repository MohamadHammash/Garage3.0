using Garage3._0.Models.ViewModels.MembersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Models.ViewModels.MembersViewModels
{
    public class BigViewModel
    {
        public IEnumerable<MembersListViewModel> Models { get; set; }
        public MembersListViewModel ListViewModel { get; set; }
    }
}
