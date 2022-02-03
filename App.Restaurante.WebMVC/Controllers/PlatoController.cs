using App.Restaurante.Models;
using App.Restaurante.UnitOfWork;
using App.Restaurante.WebMVC.Models;
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
            PlatoViewModel platoViewModel = new PlatoViewModel();
            platoViewModel.ListaSubGrupo = await _unitOfWork.SubGrupos.Listar();
            return PartialView("_Create", platoViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Create(PlatoViewModel platoViewModel) {
            if (ModelState.IsValid) {
                Plato plato = SetearPlato(platoViewModel);
                await _unitOfWork.Platos.Insertar(plato);
                return RedirectToAction("Index");
            }
            return PartialView("_Create", platoViewModel);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id) {
            PlatoViewModel platoViewModel = new PlatoViewModel();
            platoViewModel.Plato = await _unitOfWork.Platos.Obtener(id);
            platoViewModel.ListaSubGrupo = await _unitOfWork.SubGrupos.Listar();
            return PartialView("_Edit", platoViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(PlatoViewModel platoViewModel)
        {
            if (ModelState.IsValid)
            {
                Plato plato = SetearPlato(platoViewModel);
                await _unitOfWork.Platos.Modificar(plato);
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", platoViewModel);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id) {
            var plato = await _unitOfWork.Platos.Obtener(id);
            return PartialView("_Delete", plato);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            if ((await _unitOfWork.Platos.Eliminar(id)) != 0) return RedirectToAction("Index");

            return View(await _unitOfWork.Platos.Obtener(id));
        }
        private static Plato SetearPlato(PlatoViewModel platoViewModel)
        {
            Plato plato = new Plato();
            plato.IdPlato = platoViewModel.Plato.IdPlato;
            plato.Descripcion = platoViewModel.Plato.Descripcion;
            plato.Precio = platoViewModel.Plato.Precio;
            plato.IdSubGrupo = platoViewModel.Plato.IdSubGrupo;
            plato.Estado = platoViewModel.Plato.Estado;
            return plato;
        }

    }
}