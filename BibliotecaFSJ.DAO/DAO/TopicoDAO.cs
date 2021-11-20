﻿using BibliotecaFSJ.DAO.Contexto;
using BibliotecaFSJ.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

    }
}
