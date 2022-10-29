using BibliotecaFSJ.DAO.Contexto;
using BibliotecaFSJ.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.DAO.DAO
{
    public static class MensagensDAO
    {
        public static async Task<List<Conversa>> GetConversasByUsuario(string idUsuario)
        {
            using (var context = new ContextoBanco())
            {
                List<Conversa> conversas = new List<Conversa>();

                foreach (var conversa in await context.Conversas.Include(x => x.Mensagens).ToListAsync())
                {
                    var mensagensUsuario = conversa.Mensagens.Where(x => x.IdDestinatario == idUsuario);

                    foreach (var msg in mensagensUsuario)
                    {
                        conversas.Add(await context.Conversas.FindAsync(msg.Conversa.Id));
                    }
                }

                return conversas.Distinct().ToList();
            }
        }

        public static async Task<List<Conversa>> GetConversasEnviadasByUsuario(string idUsuario)
        {
            using (var context = new ContextoBanco())
            {
                List<Conversa> conversas = new List<Conversa>();

                foreach (var conversa in await context.Conversas.Include(x => x.Mensagens).ToListAsync())
                {
                    var mensagensUsuario = conversa.Mensagens.Where(x => x.IdRemetente == idUsuario);

                    foreach (var msg in mensagensUsuario)
                    {
                        conversas.Add(await context.Conversas.FindAsync(msg.Conversa.Id));
                    }
                }

                return conversas.Distinct().ToList();
            }
        }

        public static async Task<List<Mensagem>> GetMensagensByConversa(long idConversa)
        {
            using (var context = new ContextoBanco())
            {
                List<Mensagem> mensagens = new List<Mensagem>();

                mensagens = await context.Mensagens.Include(x => x.Conversa)
                    .Where(x => x.Conversa == new Conversa { Id = idConversa }).ToListAsync();

                return mensagens.OrderBy(x => x.Envio).ToList();
            }
        }

        public static async Task<Mensagem> EnviaMensagem(Mensagem mensagem)
        {
            using (var context = new ContextoBanco())
            {
                mensagem.Envio = DateTime.Now;

                await context.Mensagens.AddAsync(mensagem);

                await context.SaveChangesAsync();

                return mensagem;
            }
        }
    }
}