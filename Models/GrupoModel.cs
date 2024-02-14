namespace tcc_chat.Models
{
    public class GrupoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<UsuarioModel> Usuarios { get; set; }
        public List<MensagemModel> Mensagens { get; set; }
    }
}