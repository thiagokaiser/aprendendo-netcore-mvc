using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.Services;
using Core.Models;

namespace SiteWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            var categoria = categoriaService.List();
            return View(categoria);
        }

        public IActionResult Excluir(int id)
        {
            categoriaService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var categoria = categoriaService.SelectById(id) ?? new Categoria();
            return View(categoria);
        }

        public IActionResult Gravar(Categoria categoria)
        {

            if (categoria.Id > 0)
            {
                categoriaService.Update(categoria);
            }
            else
            {
                categoriaService.New(categoria);
            }            

            return RedirectToAction("Index");
        }
    }
}