using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Services;
using Core.Models;

namespace SiteWeb.Controllers
{
    public class DespesaController : Controller
    {
        private readonly DespesaService despesaService;
        private readonly CategoriaService categoriaService;

        public DespesaController(DespesaService despesaService, CategoriaService categoriaService)
        {
            this.despesaService = despesaService;
            this.categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            var despesas = despesaService.List();
            return View(despesas);
        }

        public IActionResult Excluir(int id)
        {
            despesaService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var categ = categoriaService.List();
            ViewBag.Categoria = categ.Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() });

            var despesa = despesaService.SelectById(id) ?? new Despesa();

            return View(despesa);
        }

        public IActionResult Gravar(Despesa despesa)
        {

            if (despesa.Id > 0)
            {
                despesaService.Update(despesa);
            }
            else
            {
                despesaService.New(despesa);
            }
            return RedirectToAction("Index");
        }
    }
}