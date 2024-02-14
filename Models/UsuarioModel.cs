using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace tcc_chat.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int CargoId { get; set; }

        public List<SelectListItem> Cargos { get; set; }
        public List<GrupoModel> Grupos { get; set; }
    }
}