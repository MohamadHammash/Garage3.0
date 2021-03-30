using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Data;
using Garage3._0.Models.Entities;
using AutoMapper;
using Bogus;
using Garage3._0.Models.ViewModels.MembersViewModels;


namespace Garage3._0.Controllers
{
    public class MembersController : Controller
    {
        private readonly Garage3_0Context db;
        private readonly IMapper mapper;
        private Faker faker;

        public MembersController(Garage3_0Context context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
            faker = new Faker("sv");
        }

        // GET: Members
        //public async Task<IActionResult> Index()
        //{

        //    var model = mapper.ProjectTo<MembersListViewModel>(db.Members).Take(15);
        //    return View(await model.ToListAsync());

        //    //return View(await db.Members.ToListAsync());
        //}

        public async Task<IActionResult> Index(string sortOrder, string searchString, int page = 0, int pagesize = 20)
        {

            ViewData["FullNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fullName_desc" : "";


            ViewData["PersonNumberSortParm"] = String.IsNullOrEmpty(sortOrder) ? "personNumber_desc" : "";

            ViewData["CurrentFilter"] = searchString;
            //var members = db.Members;
            var members = from m in db.Members
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                //  members = members.Where(s => s.FirstName.ToUpper() StartsWith(searchString.Substring(0).ToUpper()+searchString.Substring(1).ToUpper()));
                members = members.Where(s => s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "fullName_desc":

                    members = members.OrderByDescending(m => m.FirstName.Substring(0, 2));
                    break;
                case "personNumber_desc":
                    members = members.OrderByDescending(s => s.Personnummer);
                    break;
                default:
                    members = members.OrderBy(m => m.FirstName);
                    break;
            }
            var model = mapper.ProjectTo<MembersListViewModel>(members);
            int PageSize = pagesize; // you can always do something more elegant to set this

            var count = model.Count();

            var data = model.Skip((int)(page * PageSize)).Take(PageSize);

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = page;
            return View(await data.ToListAsync());
        }

        //public async Task<IActionResult> Index(int page = 0, int pagesize = 20)
        //{
        //    var model =  mapper.ProjectTo<MembersListViewModel>(db.Members).Take(150);
           
        //     int PageSize = pagesize; // you can always do something more elegant to set this

        //    var count = model.Count();

        //    var data = model.Skip((int)(page * PageSize)).Take(PageSize).ToList();

        //    this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

        //    this.ViewBag.Page = page;


        //    return View(data);
            
        //}

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await mapper
                .ProjectTo<MembersDetailsViewModel>(db.Members)
                .FirstOrDefaultAsync(m => m.Id == id);

           
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Add()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add( MembersAddViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {

                var member = mapper.Map<Member>(viewmodel);
                member.MbShipRegDate = DateTime.Today;
                if (IsSenior(member.Personnummer))
                {
                    member.ProEndDate = DateTime.Today.AddYears(2);
                }
                else
                {
                member.ProEndDate = DateTime.Today.AddMonths(1);
                }



                    db.Add(member);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(AddSuccess));
            }
            return View(viewmodel);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Personnummer,MbShipRegDate,ProEndDate")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(member);
                    await db.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(SuccessEdit));
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await db.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var member = await db.Members.FindAsync(id);
            db.Members.Remove(member);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(DeleteSuccess));
        }

        private bool MemberExists(int id)
        {
            return db.Members.Any(e => e.Id == id);
        }
        public IActionResult PersNumExists(string personnummer, int id)
        {
            var garage = db.Members;
            if (garage.Any(v => personnummer == v.Personnummer && id != v.Id))
            {
                return Json($"You are already a member");
            }
            return Json(true);
        }
        public IActionResult SuccessEdit()
        {
            return View();
        }

        public IActionResult AddSuccess()
        {
            return View();
        }

        public IActionResult DeleteSuccess()
        {
            return View();
        }

        private int GetAge(string personnummer)
        {
            var builder = new CustomBuilders();
            var year = builder.GetAge(personnummer);
            return year;
        }
        private bool IsSenior(string personnummer)
        {
            var year = GetAge(personnummer);
            if (DateTime.Today.Year - year < 65)
            {
                return false;
            }
            return true;
        }

    }
}
