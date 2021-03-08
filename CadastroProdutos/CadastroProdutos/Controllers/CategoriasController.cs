using CadastroProdutos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CadastroProdutos.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
            {
                new Categoria() { CategoriaId = 1, Nome = "Notebooks" },
                new Categoria() { CategoriaId = 2, Nome = "Monitores" },
                new Categoria() { CategoriaId = 3, Nome = "Impressoras" },
                new Categoria() { CategoriaId = 4, Nome = "Mouses" },
                new Categoria() { CategoriaId = 5, Nome = "Desktops" }
            };

        public ActionResult Index()
        {
            return View(categorias.OrderBy(c => c.Nome));
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Categoria categoria)
        {
            categoria.CategoriaId = categorias.Select(c => c.CategoriaId).Max() + 1;

            categorias.Add(categoria);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(long id)
        {
            return View(categorias.Where(c => c.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Categoria categoria)
        {
            categorias[categorias.IndexOf(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First())] = categoria;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Visualizar(long id)
        {
            return View(categorias.Where(c => c.CategoriaId == id).First());
        }

        [HttpGet]
        public ActionResult Excluir(long id)
        {
            return View(categorias.Where(c => c.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());

            return RedirectToAction("Index");
        }
    }
}