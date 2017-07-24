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
    public class ProveedoresController : Controller
    {
        private readonly FSVentasCoreDb _context;

        public ProveedoresController(FSVentasCoreDb context)
        {
            _context = context;    
        }

        // GET: Proveedores
        public async Task<IActionResult> Index()
        {
            var fSVentasCoreDb = _context.Proveedores.Include(p => p.DistritosMunicipales).Include(p => p.MarcasArticulos).Include(p => p.Municipios).Include(p => p.Provincias).Include(p => p.Sectores);
            return View(await fSVentasCoreDb.ToListAsync());
        }

        // GET: Proveedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = await _context.Proveedores
                .Include(p => p.DistritosMunicipales)
                .Include(p => p.MarcasArticulos)
                .Include(p => p.Municipios)
                .Include(p => p.Provincias)
                .Include(p => p.Sectores)
                .SingleOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedores == null)
            {
                return NotFound();
            }

            return View(proveedores);
        }

        // GET: Proveedores/Create
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.DistritosMunicipales, "DistritoId", "DistritoId");
            ViewData["MarcaId"] = new SelectList(_context.MarcasArticulos, "MarcaId", "MarcaId");
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId");
            ViewData["SectorId"] = new SelectList(_context.Parajes, "ParajeId", "ParajeId");
            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProveedorId,Nombre,MarcaId,ProvinciaId,MunicipioId,DistritoId,SectorId,Direccion,Telefono,Fax,Correo,Fecha")] Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedores);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DistritoId"] = new SelectList(_context.DistritosMunicipales, "DistritoId", "DistritoId", proveedores.DistritoId);
            ViewData["MarcaId"] = new SelectList(_context.MarcasArticulos, "MarcaId", "MarcaId", proveedores.MarcaId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId", proveedores.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", proveedores.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Parajes, "ParajeId", "ParajeId", proveedores.SectorId);
            return View(proveedores);
        }

        // GET: Proveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = await _context.Proveedores.SingleOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedores == null)
            {
                return NotFound();
            }
            ViewData["DistritoId"] = new SelectList(_context.DistritosMunicipales, "DistritoId", "DistritoId", proveedores.DistritoId);
            ViewData["MarcaId"] = new SelectList(_context.MarcasArticulos, "MarcaId", "MarcaId", proveedores.MarcaId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId", proveedores.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", proveedores.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Parajes, "ParajeId", "ParajeId", proveedores.SectorId);
            return View(proveedores);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProveedorId,Nombre,MarcaId,ProvinciaId,MunicipioId,DistritoId,SectorId,Direccion,Telefono,Fax,Correo,Fecha")] Proveedores proveedores)
        {
            if (id != proveedores.ProveedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedoresExists(proveedores.ProveedorId))
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
            ViewData["DistritoId"] = new SelectList(_context.DistritosMunicipales, "DistritoId", "DistritoId", proveedores.DistritoId);
            ViewData["MarcaId"] = new SelectList(_context.MarcasArticulos, "MarcaId", "MarcaId", proveedores.MarcaId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId", proveedores.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", proveedores.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Parajes, "ParajeId", "ParajeId", proveedores.SectorId);
            return View(proveedores);
        }

        // GET: Proveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = await _context.Proveedores
                .Include(p => p.DistritosMunicipales)
                .Include(p => p.MarcasArticulos)
                .Include(p => p.Municipios)
                .Include(p => p.Provincias)
                .Include(p => p.Sectores)
                .SingleOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedores == null)
            {
                return NotFound();
            }

            return View(proveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedores = await _context.Proveedores.SingleOrDefaultAsync(m => m.ProveedorId == id);
            _context.Proveedores.Remove(proveedores);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProveedoresExists(int id)
        {
            return _context.Proveedores.Any(e => e.ProveedorId == id);
        }
    }
}
