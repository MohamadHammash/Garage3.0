﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Data;
using Garage3._0.Models.Entities;
using Garage3._0.Models.ViewModels.VehiclesViewModels;
using AutoMapper;
using Bogus;

namespace Garage3._0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage3_0Context db;
        private readonly IMapper mapper;
        private Faker faker;

        public VehiclesController(Garage3_0Context context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
            faker = new Faker("sv");
        }

        // GET: Vehicles
        //public async Task<IActionResult> Index()
        //{

        //    var model = mapper.ProjectTo<VehiclesListViewModel>(db.Vehicles).Take(15);
        //    return View(await model.ToListAsync());
        //    //var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);
        //    //return View(await vehicles.ToListAsync());
        ////public async Task<IActionResult> Index()
        ////{
        ////    var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);
        ////    return View(await vehicles.ToListAsync());
        //}


        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["VehicleTypeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fordonType_desc" : "";
            ViewData["RegisNrSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Regist_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var vehicles = mapper.ProjectTo<VehiclesListViewModel>(db.Vehicles).Take(15);
            //var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType).AsQueryable();

            //var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);
            //var vehicles = db.Vehicles;


            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.RegNr.StartsWith(searchString));

            }
            switch (sortOrder)
            {
                case "fordonType_desc":
                    vehicles = vehicles.OrderByDescending(v => v.VehicleType.TypeName);
                    break;
                case "Regist_desc":
                    vehicles = vehicles.OrderByDescending(v => v.RegNr);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.VehicleType.TypeName);
                    break;
            }


            return View(await vehicles.AsNoTracking().ToListAsync());
        }
        
        //GET: Vehicles
        public async Task<IActionResult> Index(int page = 0, int pagesize = 20)
        {
            var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);
            int PageSize = pagesize; // you can always do something more elegant to set this

            var count = vehicles.Count();

            var data = vehicles.Skip((int)(page * PageSize)).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = page;

            return View(data);
        }
            
        


        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await db.Vehicles
                .Include(v => v.Member)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Park
        public IActionResult Park()
        {
            ViewData["MemberId"] = new SelectList(db.Set<Member>(), "Id", "Id");
            ViewData["VehicleTypeId"] = new SelectList(db.Set<VehicleType>(), "Id", "Id");
            return View();
        }

        // POST: Vehicles/Park
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park(VehiclesParkViewModel viewModel)
        {

            if (RegNrExists(viewModel.RegNr, viewModel.Id))
            {
                ModelState.AddModelError("RegNr", "Vehicle already exists");
            }
            if (ModelState.IsValid)
            {
                var vehicle = mapper.Map<Vehicle>(viewModel);
                vehicle.ArrivalTime = DateTime.Now;
                
                //vehicle.VehicleType.NumberOfSpots = faker.Random.Int(1, 3);


                ViewData["MemberId"] = new SelectList(db.Set<Member>(), "Id", "Id", vehicle.MemberId);
                ViewData["VehicleTypeId"] = new SelectList(db.Set<VehicleType>(), "Id", "Id", vehicle.VehicleTypeId);
                db.Add(vehicle);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["MemberId"] = new SelectList(db.Set<Member>(), "Id", "FirstName", vehicle.MemberId);
            //ViewData["VehicleTypeId"] = new SelectList(db.Set<VehicleType>(), "Id", "Id", vehicle.VehicleTypeId);
            return View(viewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(db.Set<Member>(), "Id", "FirstName", vehicle.MemberId);
            ViewData["VehicleTypeId"] = new SelectList(db.Set<VehicleType>(), "Id", "Id", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Color,RegNr,NumberOfwheeels,ArrivalTime,VehicleTypeId,MemberId")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(vehicle);
                    db.Entry(vehicle).Property(x => x.ArrivalTime).IsModified = false;
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(db.Set<Member>(), "Id", "FirstName", vehicle.MemberId);
            ViewData["VehicleTypeId"] = new SelectList(db.Set<VehicleType>(), "Id", "Id", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Unpark/5
        public async Task<IActionResult> Unpark(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await db.Vehicles
                .Include(v => v.Member)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Unpark/5
        [HttpPost, ActionName("Unpark")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnparkConfirmed(int id)
        {
            var vehicle = await db.Vehicles.FindAsync(id);
            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return db.Vehicles.Any(e => e.Id == id);
        }
        public bool RegNrExists(string regNr, int id)
        {
            var garage = db.Vehicles;
            return (garage.FirstOrDefault(v => regNr == v.RegNr && id != v.Id) is null ? false : true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult RegNumExists(string regNr, int id)
        {
            var garage = db.Vehicles;
            if (garage.Any(v => regNr == v.RegNr && id != v.Id))
            {
                return Json($"Vehicle already exits");
            }
            return Json(true);
        }
        private async Task<IEnumerable<SelectListItem>> GetTypeAsync()
        {
            return await db.VehicleTypes
                          .Select(v => v.TypeName)
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
