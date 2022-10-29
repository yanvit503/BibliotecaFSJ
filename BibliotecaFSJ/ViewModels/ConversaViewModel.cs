namespace BibliotecaFSJ.ViewModels
{
    public class ConversaListaViewModel
    {
        public long Id { get; set; }
        public string NomeUsuario { get; set; }
        public string ConteudoUltimaMensagem { get; set; }
        public string DataUltimaMensagem { get; set; }
    }

    public class MensagemListaViewModel
    {
        public long Id { get; set; }
        public long IdConversa { get; set; }
        public string IdRemetente { get; set; }
        public string NomeRemetente { get; set; }
        public string ConteudoMensagem { get; set; }
        public string DataMensagem { get; set; }
    }
}
