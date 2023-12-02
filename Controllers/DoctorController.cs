using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = _context.Doctores.ToList();
            return View(doctores);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _context.Doctores.FirstOrDefault(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nombre,Especialidad")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _context.Doctores.FirstOrDefault(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre,Especialidad")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _context.Doctores.FirstOrDefault(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = _context.Doctores.Find(id);
            _ = _context.Doctores.Remove(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //API
        [HttpGet]
    public IActionResult GetDoctors()
    {
        List<Doctor> doctores = _context.Doctores.ToList();
        return Ok(doctores);
    }

    [HttpGet("{id}")]
    public IActionResult GetDoctor(int id)
    {
        var doctor = _context.Doctores.FirstOrDefault(m => m.Id == id);
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }

    [HttpPost]
    public IActionResult CreateDoctor([FromBody] Doctor doctor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(doctor);
            _context.SaveChanges();
            return Ok(doctor);
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDoctor(int id, [FromBody] Doctor doctor)
    {
        if (id != doctor.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _context.Update(doctor);
            _context.SaveChanges();
            return Ok(doctor);
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDoctor(int id)
    {
        var doctor = _context.Doctores.Find(id);
        if (doctor == null)
        {
            return NotFound();
        }

        _context.Doctores.Remove(doctor);
        _context.SaveChanges();
        return Ok(doctor);
    }

        private const string SecretKey = "micontraseñasegura12345_"; // Clave secreta para JWT
        private const string Username = "usuario"; // Clave secreta para JWT
        private const string Password = "contraseña"; // Clave secreta para JWT
        
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            if (IsValidUser(username, password))
            {
                var token = GenerateToken(username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        private bool IsValidUser(string username, string password)
        {
            // Aquí verifica la validez del usuario y contraseña (puede ser con base de datos u otro mecanismo)
            return username == "usuario" && password == "contraseña";
        }

        private string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5149", // Cambia esta URL si corresponde a otro dominio
                audience: "https://localhost:5149", // Cambia esta URL si corresponde a otro dominio
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
