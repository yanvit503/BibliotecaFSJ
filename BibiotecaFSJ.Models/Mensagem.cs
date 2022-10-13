using System;

namespace BibliotecaFSJ.Models
{
    public class Mensagem
    {
        public long Id { get; set; }
        public string IdDestinatario { get; set; }
        public Conversa Conversa { get; set; }
        public string Conteudo { get; set; }
        public DateTime Envio { get; set; }
    }
}