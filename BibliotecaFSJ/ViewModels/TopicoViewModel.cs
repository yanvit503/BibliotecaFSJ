using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.ViewModels
{
    public class TopicoViewModel
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Imagens { get; set; }
    }
}
