using Microsoft.AspNetCore.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class MensagensController : Controller
    {
        public IActionResult Bomdia()
        {
            return Content("Bom dia");
        }

        public IActionResult BoaTarde()
        {
            return Content("Boa tarde");
        }
    }
}
