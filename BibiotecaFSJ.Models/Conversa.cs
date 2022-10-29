using System;
using System.Collections.Generic;

namespace BibliotecaFSJ.Models
{
    public class Conversa : IEquatable<Conversa>
    {
        public long Id { get; set; }
        public List<Mensagem> Mensagens { get; set; }

        public bool Equals(Conversa other)
        {
            return Id == other.Id; 
        }
    }
}