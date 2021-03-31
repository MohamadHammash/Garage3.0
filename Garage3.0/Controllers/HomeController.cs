using AutoMapper;
using Bogus;
using Garage3._0.Data;
using Garage3._0.Models;
using Garage3._0.Models.ViewModels.MembersViewModels;
using Garage3._0.Models.ViewModels.StatisticsViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Controllers
{
    public class HomeController : Controller
    {

        private readonly Garage3_0Context db;
        private readonly IMapper mapper;
        private Faker faker;

        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger, Garage3_0Context context, IMapper mapper)
        {
            _logger = logger;
            db = context;
            this.mapper = mapper;
            faker = new Faker("sv");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        //public IActionResult Statistics(StatisticsViewModel viewModel)
        //{
        //    var vehicles = mapper.ProjectTo<StatisticsViewModel>(db.Vehicles).Take(150);

        //    return View(viewModel);
        //}


        public IActionResult Statistics()
        {
            var members = from m in db.Members
                          select m;
            var model = mapper.ProjectTo<MembersListViewModel>(members);
            return View(model);

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
