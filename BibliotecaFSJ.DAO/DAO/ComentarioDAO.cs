using BibliotecaFSJ.DAO.Contexto;
using BibliotecaFSJ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFSJ.DAO.DAO
{
    public static class ComentarioDAO
    {
        public static async Task<List<Comentario>> GetComentariosByTopico(int idTopico)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    var result = await context.Comentarios.Where(x => x.IdTopico.Equals(idTopico)).OrderByDescending(x => x.Horario).ToListAsync();

                    return result;
                }
            }
            catch 
            {

                return null;
            }
        }

        public static async Task<Comentario> SalvaComentario(Comentario comentario)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    context.Comentarios.Add(comentario);
                    var result = await context.SaveChangesAsync();

                    if (result > 0)
                        return comentario;

                    return null;
                }
            }
            catch 
            {
                return null;
            }
        }

        public static async Task<bool> ExcluirComentario(int comentarioId)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    var comentario = await context.Comentarios.FindAsync(comentarioId);

                    context.Comentarios.Remove(comentario);

                    var result = await context.SaveChangesAsync();

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
