using CadeMeuMedico.Context;
using Microsoft.AspNetCore.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class TesteLayoutController : Controller
    {
        public IActionResult Teste()
        {
            return View();
        }

        public IActionResult Teste2() {

        return View();

        }

    }
}
