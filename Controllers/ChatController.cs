using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tcc_chat.Models;
using tcc_chat.Services;

namespace tcc_chat.Controllers
{
    public class ChatController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public ChatController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Chat(int id = 0)
        {
            var mensagens = _context.Mensagens.Include(m => m.Usuario).Where(m => m.Grupo.Id == id).OrderBy(m => m.Envio).ToList();
            ViewData["mensagens"] = mensagens;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
