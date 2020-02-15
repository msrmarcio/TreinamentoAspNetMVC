using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// importa o namespce de onde esta a classe
using Editora.WebMvc.Web.Utils;

namespace Editora.WebMvc.Web.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contato()
        {
            ViewBag.MensagemEnviada = null;

            // retorna o HTML da view correspondente com a actionResult contato
            return View();
        }

        [HttpPost]
        public ActionResult Contato(FormCollection form)
        {
            try
            {
                var emailRemetente = "msrmarcio@outlook.com";
                var nomeRemetente = form["Nome"];
                var emailDestinatario = form["Email"];
                var assunto = form["Assunto"];
                var mensagem = form["Mensagem"];

                // vamos usar a classe de envio de email
                EnviarEmail email = new EnviarEmail(emailRemetente, nomeRemetente,
                    emailDestinatario, mensagem, assunto);

                // TODO: comentado para testar  depois
                // email.Send();

                ViewBag.MensagemEnviada = "Mensagem enviada com sucesso"; 
                
            }
            catch (Exception ex)
            {
                // inserimos uma mensagem de erro
                ViewBag.Erro = ex.Message;
            }


            return View();
        }


    }
}