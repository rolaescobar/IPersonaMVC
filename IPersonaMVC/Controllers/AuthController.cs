using IPersonaMVC.Data;
using IPersonaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPersonaMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.HideNavBar = false; 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario userLogin)
        {
           
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == userLogin.NombreUsuario && u.ClaveUsuario == userLogin.ClaveUsuario);

            if (user != null && user.Activo == true) 
            {
               
                HttpContext.Session.SetString("Username", userLogin.NombreUsuario);

                ViewData["Username"] = userLogin.NombreUsuario;

                return RedirectToAction("Welcome", "Home"); 
            }

            ViewBag.HideNavBar = true;
            ViewBag.Error = "Credenciales inválidas";
            return View();
        }

  
        [HttpPost]
        public IActionResult Logout()
        {
   
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
