using Microsoft.EntityFrameworkCore;
using tcc_chat.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace tcc_chat.Services
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<CargoModel> CargoModel { get; set; }
        public DbSet<MensagemModel> Mensagens { get; set; }
        public DbSet<GrupoModel> Grupos { get; set; }
    }
}