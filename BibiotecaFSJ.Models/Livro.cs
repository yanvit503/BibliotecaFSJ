using System;
using System.ComponentModel.DataAnnotations;

namespace BibiotecaFSJ.Models
{
    public class Livro
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
