namespace BibliotecaFSJ.ViewModels
{
    public class ContaViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string ImagemUrl
        {
            get 
            {
                return "/Imagens/User/" + Id + ".jpg";
            }
        }
    }
}
