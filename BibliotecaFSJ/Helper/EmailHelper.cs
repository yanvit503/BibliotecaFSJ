using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Helper
{
    public class EmailHelper
    {
        public static void EnviaEmail(string DestinartarioEmail, string Assunto, string Texto, bool isHtml = true)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "d8decec8-1c79-4002-880b-447d73ef400f");

            var data = new JsonContent(new
            {
                Emails = new string[] { DestinartarioEmail },
                Subject = Assunto,
                Content = Texto
            });

            var res = httpClient.PostAsync("https://emi.solucoesvirtuais.net/email/send", data).Result;

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception("Erro no serviço de email.");
            }
        }
    }
}
