using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Camilo_Rendon.Models;

namespace Camilo_Rendon.Controllers
{
    public class CitasMedicasController : Controller
    {
        private readonly ClinicaDbContext _context;

        public CitasMedicasController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: CitasMedicas
        public async Task<IActionResult> Index()
        {
            var clinicaDbContext = _context.CitasMedicas.Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation);
            return View(await clinicaDbContext.ToListAsync());
        }

        // GET: CitasMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citasMedica = await _context.CitasMedicas
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (citasMedica == null)
            {
                return NotFound();
            }

            return View(citasMedica);
        }

        // GET: CitasMedicas/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente");
            return View();
        }

        // POST: CitasMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,IdPaciente,IdMedico,FechaHora,Estado")] CitasMedica citasMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citasMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", citasMedica.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", citasMedica.IdPaciente);
            return View(citasMedica);
        }

        // GET: CitasMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citasMedica = await _context.CitasMedicas.FindAsync(id);
            if (citasMedica == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", citasMedica.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", citasMedica.IdPaciente);
            return View(citasMedica);
        }

        // POST: CitasMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCita,IdPaciente,IdMedico,FechaHora,Estado")] CitasMedica citasMedica)
        {
            if (id != citasMedica.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citasMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitasMedicaExists(citasMedica.IdCita))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", citasMedica.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", citasMedica.IdPaciente);
            return View(citasMedica);
        }

        // GET: CitasMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citasMedica = await _context.CitasMedicas
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (citasMedica == null)
            {
                return NotFound();
            }

            return View(citasMedica);
        }

        // POST: CitasMedicas/Delete/5
     
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citasMedica = await _context.CitasMedicas.FindAsync(id);
            if (citasMedica != null)
            {
                _context.CitasMedicas.Remove(citasMedica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitasMedicaExists(int id)
        {
            return _context.CitasMedicas.Any(e => e.IdCita == id);
        }
    }
}
