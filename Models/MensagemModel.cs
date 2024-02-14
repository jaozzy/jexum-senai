using System;
using tcc_chat.Models;

namespace tcc_chat {
    public class MensagemModel {
        public int Id { get; set; }
        public UsuarioModel Usuario { get; set; }
        public GrupoModel Grupo { get; set; }
        public string Conteudo { get; set; }
        public DateTime Envio { get; set; }
        public MensagemModel () {
            Envio = DateTime.UtcNow;
        }
    }
}