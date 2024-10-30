using CadeMeuMedico.Context;
using CadeMeuMedico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private MedicosContext _medicosContext = new();
        private CidadesContext _cidadesContext = new();
        private EspecialidadesContext _especialidadesContext = new();
        
        public IActionResult Index()
        {
            List<Medicos>? medicos = _medicosContext.GetList();
            return View(medicos);
        }

        public IActionResult Adicionar()
        {
            ViewBag.IdCidade = new SelectList(_cidadesContext.GetList(),"Id","Cidade");
            ViewBag.IdEspecialidade = new SelectList(_especialidadesContext.GetList(), "Id", "Especialidade");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                _medicosContext.Insert(medico);
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(_cidadesContext.GetList(), "Id","Cidade",medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(_especialidadesContext.GetList(),"Id","Especialidade",medico.IdEspecialidade);
            return View(medico);
        }

        public IActionResult Editar(int id) { 

            Medicos? medico = _medicosContext.GetById(id);
            ViewBag.IdCidade = new SelectList(_cidadesContext.GetList(), "Id", "Cidade", medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(_especialidadesContext.GetList(), "Id", "Especialidade", medico.IdEspecialidade);
            
            return View(medico);

        }

        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                _medicosContext.Update(medico);
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(_cidadesContext.GetList(), "Id", "Cidade", medico.IdCidade);
            ViewBag.IdEspecialidade = new SelectList(_especialidadesContext.GetList(), "Id", "Especialidade", medico.IdEspecialidade);
            return View(medico);
        }

        public IActionResult Delete(int id)
        {
            Medicos? medico = _medicosContext.GetById(id);
            return View(medico);
        }

        [HttpPost]
        public ActionResult Delete(Medicos medico) {

            if (medico is not null) 
                if (_medicosContext.Delete(medico)) 
                    return RedirectToAction("Index");
            
            return BadRequest();

        }

    }
}
