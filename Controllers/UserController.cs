using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using tcc_chat.Services;
using tcc_chat.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace tcc_chat.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(UsuarioModel usuario)
        {
            try
            {
                var user = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);

                if (user == null || user.Senha != usuario.Senha)
                {
                    return Json(new { success = false });
                }
                else
                {
                    return Json(new { success = true, redirectUrl = Url.Action("Chat", "Chat") });
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocorreu um erro durante o login. Tente novamente mais tarde.";
                return Json(new { success = false });
            }
        }

        public IActionResult Register() {

            var cargos = _context.CargoModel.ToList();
            var viewModel = new UsuarioModel
            {
                Cargos = cargos.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nome }).ToList()
            };

            return View(viewModel);
        }

    }
}