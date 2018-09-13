using SiteWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SiteWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private CrudDbContext _crudContext;

        public CategoriaController(CrudDbContext crudContext)
        {
            _crudContext = crudContext;
        }

        public IActionResult Index()
        {
            var categoria = _crudContext.Categoria.AsNoTracking().ToList();
            return View(categoria);
        }

        public IActionResult Excluir(int id)
        {
            var categoria = _crudContext.Categoria.Single(p => p.Id == id);
            _crudContext.Remove(categoria);
            _crudContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var categoria = _crudContext.Categoria.FirstOrDefault(p => p.Id == id) ?? new Categoria();

            return View(categoria);
        }

        public IActionResult Gravar(Categoria categoria)
        {

            if (categoria.Id > 0)
            {
                _crudContext.Update(categoria);
            }
            else
            {
                _crudContext.Add(categoria);
            }

            _crudContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}