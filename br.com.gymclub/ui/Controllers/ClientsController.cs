using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.context;
using api.models;

namespace ui.Controllers
{
    public class ClientsController : Controller
    {
        private readonly AppDbContext _context;
        
        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Client.Include(c => c.city).Include(c => c.planType).Include(c => c.state).Include(c => c.typePayment);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.city)
                .Include(c => c.planType)
                .Include(c => c.state)
                .Include(c => c.typePayment)
                .FirstOrDefaultAsync(m => m.IdRegistration == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["idCity"] = new SelectList(_context.City, "Id", "Name");
            ViewData["idPlanType"] = new SelectList(_context.PlanType, "Id", "Name");
            ViewData["idState"] = new SelectList(_context.State, "Id", "Name");
            ViewData["idTypePayment"] = new SelectList(_context.TypePayment, "Id", "Name");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistration,Street,Neighborhood,idCity,idState,ContractStartDate,ContractEndDate,idPlanType,idTypePayment,idUser,CreatedAt,UpdatedAt,DeletedAt")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCity"] = new SelectList(_context.City, "Id", "Name", client.idCity);
            ViewData["idPlanType"] = new SelectList(_context.PlanType, "Id", "Name", client.idPlanType);
            ViewData["idState"] = new SelectList(_context.State, "Id", "Name", client.idState);
            ViewData["idTypePayment"] = new SelectList(_context.TypePayment, "Id", "Name", client.idTypePayment);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["idCity"] = new SelectList(_context.City, "Id", "Name", client.idCity);
            ViewData["idPlanType"] = new SelectList(_context.PlanType, "Id", "Name", client.idPlanType);
            ViewData["idState"] = new SelectList(_context.State, "Id", "Name", client.idState);
            ViewData["idTypePayment"] = new SelectList(_context.TypePayment, "Id", "Name", client.idTypePayment);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistration,Street,Neighborhood,idCity,idState,ContractStartDate,ContractEndDate,idPlanType,idTypePayment,idUser,CreatedAt,UpdatedAt,DeletedAt")] Client client)
        {
            if (id != client.IdRegistration)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.IdRegistration))
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
            ViewData["idCity"] = new SelectList(_context.City, "Id", "Name", client.idCity);
            ViewData["idPlanType"] = new SelectList(_context.PlanType, "Id", "Name", client.idPlanType);
            ViewData["idState"] = new SelectList(_context.State, "Id", "Name", client.idState);
            ViewData["idTypePayment"] = new SelectList(_context.TypePayment, "Id", "Name", client.idTypePayment);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.city)
                .Include(c => c.planType)
                .Include(c => c.state)
                .Include(c => c.typePayment)
                .FirstOrDefaultAsync(m => m.IdRegistration == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.FindAsync(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.IdRegistration == id);
        }
    }
}
