using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string Texto { get; set; }
        public string IdAutor { get; set; }
        public int IdTopico { get; set; }
        public DateTime Horario { get; set; }
    }
}
