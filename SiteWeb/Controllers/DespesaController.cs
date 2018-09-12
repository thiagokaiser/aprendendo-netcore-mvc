using SiteWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SiteWeb.Controllers
{
    public class DespesaController : Controller
    {
        private CrudDbContext _crudContext;

        public DespesaController(CrudDbContext crudContext)
        {
            _crudContext = crudContext;
        }

        public IActionResult Index()
        {
            var despesa = _crudContext.Despesa.AsNoTracking().ToList();
            return View(despesa);
        }

        public IActionResult Excluir(int id)
        {
            var despesa = _crudContext.Teste.Single(p => p.Id == id);
            _crudContext.Remove(despesa);
            _crudContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var despesa = _crudContext.Despesa.FirstOrDefault(p => p.Id == id) ?? new Despesa();

            return View(despesa);
        }

        public IActionResult Gravar(Despesa despesa)
        {

            if (despesa.Id > 0)
            {
                _crudContext.Update(despesa);
            }
            else
            {
                _crudContext.Add(despesa);
            }

            _crudContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}