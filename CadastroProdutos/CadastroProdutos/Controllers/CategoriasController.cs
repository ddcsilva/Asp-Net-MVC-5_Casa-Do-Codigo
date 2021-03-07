using CadastroProdutos.Models;
using System.Collections.Generic;
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
            return View(categorias);
        }
    }
}