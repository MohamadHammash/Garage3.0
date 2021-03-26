using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Data;
using Garage3._0.Models.Entities;

namespace Garage3._0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage3_0Context db;

        public VehiclesController(Garage3_0Context context)
        {
            db = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);
            return View(await vehicles.ToListAsync());
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

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(db.Set<Member>(), "Id", "FirstName");
            ViewData["VehicleTypeId"] = new SelectList(db.Set<VehicleType>(), "Id", "Id");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Color,RegNr,NumberOfWheels,ArrivalTime,VehicleTypeId,MemberId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Add(vehicle);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(db.Set<Member>(), "Id", "FirstName", vehicle.MemberId);
            ViewData["VehicleTypeId"] = new SelectList(db.Set<VehicleType>(), "Id", "Id", vehicle.VehicleTypeId);
            return View(vehicle);
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

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
    }
}
