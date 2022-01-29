using App.Restaurante.Models;
using App.Restaurante.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.Restaurante.WebMVC.Controllers
{
    public class PlatoController : BaseController
    {
        public PlatoController(IUnitOfWork unit) : base(unit) { 
        }
        // GET: Plato
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _unitOfWork.Platos.Listar());
        }
        [HttpGet]
        public ActionResult Create() {
            return PartialView("_Create");
        }
        [HttpPost]
        public async Task<ActionResult> Create(Plato plato) {
            if (ModelState.IsValid) {
                await _unitOfWork.Platos.Agregar(plato);
                RedirectToAction("Index");
            }
            return PartialView(plato);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id) {
            var plato = await _unitOfWork.Platos.Obtener(id);
            return PartialView("_Edit", plato);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id) {
            var plato = await _unitOfWork.Platos.Obtener(id);
            return PartialView("_Delete", plato);
        }

    }
}