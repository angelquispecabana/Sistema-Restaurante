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
            var lista = await _unitOfWork.Platos.Listar("");
            return View(lista);
        }
        [HttpGet]
        public async Task<ActionResult> Create() {
            Plato plato = new Plato();
            plato.ListaSubGrupo = await _unitOfWork.SubGrupos.Listar();
            return PartialView("_Create", plato);
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
            plato.ListaSubGrupo = await _unitOfWork.SubGrupos.Listar();
            return PartialView("_Edit", plato);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Plato plato)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Platos.Modificar(plato);
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", plato);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id) {
            var plato = await _unitOfWork.Platos.Obtener(id);
            return PartialView("_Delete", plato);
        }

    }
}