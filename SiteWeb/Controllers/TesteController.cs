using SiteWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
 
namespace SiteWeb.Controllers
{
    public class TesteController : Controller
    {
        private CrudDbContext _crudContext;

        public TesteController(CrudDbContext crudContext)
        {
            _crudContext = crudContext;
        }

        public IActionResult Index()
        {
            var teste = _crudContext.Teste.AsNoTracking().ToList();
            return View(teste);
        }

        public IActionResult Excluir(int id)
        {
            var situacao = _crudContext.Teste.Single(p => p.Id == id);
            _crudContext.Remove(situacao);
            _crudContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var situacao = _crudContext.Teste.FirstOrDefault(p => p.Id == id) ?? new Teste();

            return View(situacao);
        }

        public IActionResult Gravar(Teste teste)
        {

            if (teste.Id > 0)
            {
                _crudContext.Update(teste);
            }
            else
            {
                _crudContext.Add(teste);
            }

            _crudContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}