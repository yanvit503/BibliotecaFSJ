using BibliotecaFSJ.DAO.Contexto;
using BibliotecaFSJ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.DAO.DAO
{
    public static class TopicoDAO
    {
        public static async Task<Topico> GetById(int id)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    var result = await context.Topicos.Include(x=>x.Tags).FirstOrDefaultAsync(x => x.Id.Equals(id));

                    return result;
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task<bool> Gravar(Topico topico)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    await context.Topicos.AddAsync(topico);
                    int qnt = await context.SaveChangesAsync();

                    return qnt > 0 ? true : false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static Topico GetUltimo()
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    return context.Topicos.FirstOrDefault();
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static List<Topico> GetPaginaInicial()
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    return context.Topicos.ToList();
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static List<Topico> GetPesquisa(string valor)
        {
            var retorno = new List<Topico>();

            try
            {
                using (var context = new ContextoBanco())
                {
                    retorno.AddRange(context.Topicos.Where(x => x.Texto.Contains(valor)));                   

                    var idsTopicosTags = context.Tag.Where(x => x.Texto.Contains(valor)).Select(x => x.TopicoId).ToArray();

                    retorno.AddRange(context.Topicos.Where(x => idsTopicosTags.Contains(x.Id)).ToList());

                }

                return retorno;
            }
            catch(Exception e)
            {
                return null;
            }
        }

    }
}
