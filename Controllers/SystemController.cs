using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using tcc_chat.Models;
using tcc_chat.Services;

namespace tcc_chat.Controllers {
    public class SystemController : Controller {

        private readonly EmailService _emailService;

        public SystemController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult BugReport() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarEmail([FromBody] EmailModel email)
        {
            if (email == null)
            {
                return BadRequest("Dados do e-mail não fornecidos");
            }

            List<string> destinatarios = new List<string>
            {
                "servicecontact.joao@gmail.com",
                "gabrielalexandredossantos22@gmail.com",
                "daniel100teno@gmail.com",
                "gabrielbcoxev@gmail.com"
            };

            _emailService.SendEmail(destinatarios, email.Titulo, email.Descricao);
    
            return Ok("E-mail enviado com sucesso");
        }

    }
}