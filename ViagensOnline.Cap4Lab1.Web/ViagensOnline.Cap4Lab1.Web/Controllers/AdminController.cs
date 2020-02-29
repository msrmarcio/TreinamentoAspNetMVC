using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViagensOnline.Cap4Lab1.Web.Db;
using ViagensOnline.Cap4Lab1.Web.Models;

namespace ViagensOnline.Cap4Lab1.Web.Controllers
{
    public class AdminController : Controller
    {
        private const string ActionDestinoListagem = "DestinoListagem";

        // Incluir Destino
        //
        [HttpGet]
        public ActionResult DestinoNovo()
        {
            return View();
        }

        //
        // Gravar Foto
        //
        private string GravarFoto(HttpRequestBase Request)
        {
            string nome = Path.GetFileName(Request.Files[0].FileName);
            string pastaVirtual = "~/Imagens";
            string pathVirtual = pastaVirtual + "/" + nome;
            string pathFisico = Request.MapPath(pathVirtual);
            Request.Files[0].SaveAs(pathFisico);
            return nome;
        }

        //
        // Retorna uma Instância de DbContext
        //
        private ViagensOnLineDb ObterDbContext()
        {
            return new ViagensOnLineDb();
        }

        //
        // Gravar Novo Destino
        //
        [HttpPost]
        public ActionResult DestinoNovo(Destino destino)
        {
            //Se alguma validação falhou...
            if (!ModelState.IsValid)
            {
                return View(destino);
            }
            // Foto é obrigatória
            if (Request.Files.Count == 0 ||
            Request.Files[0].ContentLength == 0)
            {
                ModelState.AddModelError("", "É necessário enviar uma Foto");
                return View(destino);
            }
            //Grava
            try
            {
                //Grava a foto e retorna o nome
                destino.Foto = GravarFoto(Request);
                using (var db = ObterDbContext())
                {
                    db.Destinos.Add(destino);
                    db.SaveChanges();
                    return RedirectToAction(ActionDestinoListagem);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(destino);
            }
        }

        public ActionResult DestinoListagem()
        {
            List<Destino> lista = null;
            using (var db = ObterDbContext())
            {
                lista = db.Destinos.ToList();
            }
            
            return View(lista);
        }

        [HttpGet]
        public ActionResult DestinoAlterar(int id)
        {
            using (var db = ObterDbContext())
            {
                var destino = db.Destinos.Find(id);
                if (destino != null) { return View(destino); }
            }

            return RedirectToAction(ActionDestinoListagem);
        }

        [HttpPost]
        public ActionResult DestinoAlterar(Destino destino)
        {
            //Se o modelo é válido..
            if (ModelState.IsValid)
            {
                using (var db = ObterDbContext())
                {
                    //Obtém o original
                    var destinoOriginal = db.Destinos.Find(destino.DestinoId);
                    //Se encontrou, altera o original
                    if (destinoOriginal != null)
                    {
                        destinoOriginal.Nome = destino.Nome;
                        destinoOriginal.Cidade = destino.Cidade;
                        destinoOriginal.Pais = destino.Pais;
                        //Altera a imagem apenas se enviou outra
                        if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0 ) {
                            destinoOriginal.Foto = GravarFoto(Request);
                        }

                        //Grava
                        db.SaveChanges();
                        return RedirectToAction(ActionDestinoListagem);
                    }
                }
            }
            //Se chegou aqui e não foi redirecionado, é porque
            // houve algum problema
            return View(destino);
        }
    }
}