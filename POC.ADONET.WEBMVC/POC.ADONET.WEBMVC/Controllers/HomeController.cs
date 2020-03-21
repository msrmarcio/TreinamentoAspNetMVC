using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using POC.ADONET.MODELS;
using POC.ADONET.BLL;

namespace POC.ADONET.WEBMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TodosLivros()
        {
            LivrosBLL livrosBll = new LivrosBLL();

            var lista = livrosBll.BuscarTodosLivros();

            // Vamos retornar uma lista TIPADA de livros
            // que obtivemos atraves da camada BUSINESS LAYER
            return View(lista);
        }

        
        public ActionResult Editar(string id)
        {
            // somente declaro a variavel do tipo LivroBLL e so devo instanciar qdo for utilizar
            LivrosBLL livrosBLL = null;
            LivroMOD livroMOD = null;

            // verifica se o status da chama post e valido
            if (ModelState.IsValid)
            {
                // verifica se o codigo chegou ou e nulo ou vazio
                if (string.IsNullOrEmpty(id))
                {
                    ModelState.AddModelError("", "O Id ou Código do livro é invalido");
                }

                //  busca o livro pelo Id
                livrosBLL = new LivrosBLL();

                // obtemos o valor de retorno para um objeto igual livroMOD
                livroMOD = livrosBLL.BuscarLivroPorId(id);

            }
            return View(livroMOD);
        }

        [HttpPost]
        public ActionResult Editar(LivroMOD livro)
        {
            // cria um objeto do tipo LivroBLL para fazer a validacao de regra de negocio
            LivrosBLL livrosBLL = null;

            if (ModelState.IsValid)
            {
                livrosBLL = new LivrosBLL();

                // vamos chamar o metodo para fazer as validacoes e inserir no BD
                livrosBLL.SalvarLivro(livro);
            }

           return RedirectToAction("TodosLivros");
        }

        public ActionResult Excluir(string id)
        {
            // cria um objeto do tipo LivroBLL para fazer a validacao de regra de negocio
            LivrosBLL livrosBLL = null;

            if (ModelState.IsValid)
            {
                livrosBLL = new LivrosBLL();

                // vamos chamar o metodo para fazer as validacoes e inserir no BD
                livrosBLL.ExcluirLivro(id);
            }

            return RedirectToAction("TodosLivros");
        }

        public ActionResult CriarNovoLivro()
        {
            LivroMOD livro = null;

            return View(livro);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}