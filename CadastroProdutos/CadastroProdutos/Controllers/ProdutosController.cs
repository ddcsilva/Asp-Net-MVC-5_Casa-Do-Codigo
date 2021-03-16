using CadastroProdutos.Contexts;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using CadastroProdutos.Models;
using System.Net;

namespace CadastroProdutos.Controllers
{
    public class ProdutosController : Controller
    {
        private EFContext context = new EFContext();

        [HttpGet]
        public ActionResult Index()
        {
            var produtos = context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(p => p.Nome);

            return View(produtos);
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Produto produto)
        {
            try
            {
                context.Produtos.Add(produto);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = context.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome", produto.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome", produto.FabricanteId);

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(produto).State = EntityState.Modified;
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }

        [HttpGet]
        public ActionResult Visualizar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            try
            {
                Produto produto = context.Produtos.Find(id);
                context.Produtos.Remove(produto);
                context.SaveChanges();
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi removido!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
