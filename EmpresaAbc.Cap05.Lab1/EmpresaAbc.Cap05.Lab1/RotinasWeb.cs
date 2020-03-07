using EmpresaAbc.Cap05.Lab1.Models;
using System;
using System.Web;
// StreamWriter
using System.IO;
// enconding
using System.Text;

namespace EmpresaAbc.Cap05.Lab1
{
    public class RotinasWeb
    {
        public static void ContatoGravar(ContatoViewModel contato)
        {
            string arquivo = HttpContext
            .Current
            .Server
            .MapPath("~/App_Data/Contatos.txt");
            using (var sw = new
            StreamWriter(arquivo,true, Encoding.UTF8))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(contato.Nome);
                sw.WriteLine(contato.Email);
                sw.WriteLine(contato.Assunto);
                sw.WriteLine(contato.Mensagem);
                sw.WriteLine(new string('-', 30));
            }
        }
    }
}