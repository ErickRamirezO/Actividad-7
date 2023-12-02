using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Paciente> pacientes = _context.Pacientes.ToList();
            return View(pacientes);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _context.Pacientes.FirstOrDefault(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nombre")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _context.Pacientes.FirstOrDefault(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _context.Pacientes.FirstOrDefault(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetAllPacientes()
        {
            List<Paciente> pacientes = _context.Pacientes.ToList();
            return Ok(pacientes);
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public IActionResult GetPaciente(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult CreatePaciente([FromBody] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                _context.SaveChanges();
                return Ok(paciente);
            }
            return BadRequest();
        }

        [Route("api/[controller]/{id}")]
        [HttpPut]
        public IActionResult UpdatePaciente(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(paciente);
                _context.SaveChanges();
                return Ok(paciente);
            }
            return BadRequest();
        }

        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult DeletePaciente(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
            return Ok(paciente);
        }
    }
}
