using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Models
{
    public class TopicoImagens
    {
        [Key]
        public int Id { get; set; }

        public int TopicoId { get; set; }

        public string Url { get; set; }

        [ForeignKey("TopicoId")]
        public Topico Topico { get; set; }
    }
}
