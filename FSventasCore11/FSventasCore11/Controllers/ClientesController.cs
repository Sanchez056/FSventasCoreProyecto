using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSventasCore11.DAL;
using FSventasCore11.Models;

namespace FSventasCore11.Controllers
{
    public class ClientesController : Controller
    {
        private readonly FSVentasCoreDb _context;

        public ClientesController(FSVentasCoreDb context)
        {
            _context = context;    
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var fSVentasCoreDb = _context.Clientes.Include(c => c.DistritosMunicipales).Include(c => c.Municipios).Include(c => c.Provincias).Include(c => c.Sectores);
            return View(await fSVentasCoreDb.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .Include(c => c.DistritosMunicipales)
                .Include(c => c.Municipios)
                .Include(c => c.Provincias)
                .Include(c => c.Sectores)
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.DistritosMunicipales, "DistritoId", "DistritoId");
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId");
            ViewData["SectorId"] = new SelectList(_context.Parajes, "ParajeId", "ParajeId");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nombre,Sexo,Cedula,ProvinciaId,MunicipioId,DistritoId,SectorId,Direccion,Telefono,Celular,Fecha")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DistritoId"] = new SelectList(_context.DistritosMunicipales, "DistritoId", "DistritoId", clientes.DistritoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId", clientes.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", clientes.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Parajes, "ParajeId", "ParajeId", clientes.SectorId);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }
            ViewData["DistritoId"] = new SelectList(_context.DistritosMunicipales, "DistritoId", "DistritoId", clientes.DistritoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId", clientes.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", clientes.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Parajes, "ParajeId", "ParajeId", clientes.SectorId);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nombre,Sexo,Cedula,ProvinciaId,MunicipioId,DistritoId,SectorId,Direccion,Telefono,Celular,Fecha")] Clientes clientes)
        {
            if (id != clientes.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.ClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DistritoId"] = new SelectList(_context.DistritosMunicipales, "DistritoId", "DistritoId", clientes.DistritoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId", clientes.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", clientes.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Parajes, "ParajeId", "ParajeId", clientes.SectorId);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .Include(c => c.DistritosMunicipales)
                .Include(c => c.Municipios)
                .Include(c => c.Provincias)
                .Include(c => c.Sectores)
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteId == id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
