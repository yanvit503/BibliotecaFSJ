using BibliotecaFSJ.DAO.Contexto;
using BibliotecaFSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFSJ.DAO.DAO
{
    public class TagDAO
    {
        public static List<Tag> GetByTopico(int topicoId)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    var results = context.Tag.Where(x => x.TopicoId.Equals(topicoId)).ToList();
                    int qnt = results.Count;

                    return qnt > 0 ? results : null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task<bool> Gravar(Tag tag)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    await context.Tag.AddAsync(tag);
                    int qnt = await context.SaveChangesAsync();

                    return qnt > 0 ? true : false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> Gravar(List<Tag> tags)
        {
            try
            {
                using (var context = new ContextoBanco())
                {
                    foreach (Tag tag in tags)
                    {
                        await context.Tag.AddAsync(tag);
                    }

                    int qnt = await context.SaveChangesAsync();

                    return qnt > 0 ? true : false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
