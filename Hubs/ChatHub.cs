using Microsoft.AspNetCore.SignalR;
using tcc_chat.Models;
using tcc_chat.Services;

namespace tcc_chat.Hubs
{
    public class ChatHub: Hub
    {
        private readonly ApplicationDbContext _context;
        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(UsuarioModel user, string message, GrupoModel idGrupo)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == user.Id);
            var grupo = _context.Grupos.FirstOrDefault(g => g.Id == 1);
            await _context.AddAsync(new MensagemModel()
            {
                Usuario = usuario,
                Grupo = grupo,
                Conteudo = message,
                Envio = DateTime.UtcNow
            });
            _context.SaveChanges();
            await Clients.All.SendAsync($"ReceiveMessage{idGrupo}", user, message);
        }
    }
}
