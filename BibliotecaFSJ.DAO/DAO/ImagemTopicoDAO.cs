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
    public static class ImagemTopicoDAO
    {

        public static async Task<bool> SalvarImagensTopico(List<TopicoImagens> imagens)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    imagens.ForEach(async x => { await context.AddAsync(x); });
                    
                    var results = await context.SaveChangesAsync();

                    return results > 0 ? true : false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static async Task<List<TopicoImagens>> GetTopicoImagensByTopicoId(int id)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    var result = await context.TopicoImagens.Where(x => x.TopicoId.Equals(id)).ToListAsync();

                    return result;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
