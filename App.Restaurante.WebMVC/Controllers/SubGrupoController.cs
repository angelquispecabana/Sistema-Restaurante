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
    public class SubGrupoController : BaseController
    {
        public SubGrupoController(IUnitOfWork unit) : base(unit)
        {
        }
        // GET: SubGrupo
        public async Task<ActionResult> Index()
        {
            var listasubgrupos = await _unitOfWork.SubGrupos.Listar("");            
            return View(listasubgrupos);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            SubGrupo subGrupo = new SubGrupo();
            subGrupo.ListaGrupo = await _unitOfWork.Grupos.Listar();
            return PartialView("_Create", subGrupo);            
        }
        [HttpPost]
        public async Task<ActionResult> Create(SubGrupo subGrupo)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.SubGrupos.Agregar(subGrupo);
                RedirectToAction("Index");
            }
            return PartialView(subGrupo);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var subgrupo = await _unitOfWork.SubGrupos.Obtener(id);
            subgrupo.ListaGrupo = await _unitOfWork.Grupos.Listar();
            return PartialView("_Edit", subgrupo);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(SubGrupo subGrupo) {
            if (ModelState.IsValid) {
                await _unitOfWork.SubGrupos.Modificar(subGrupo);
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", subGrupo);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var subgrupo = await _unitOfWork.SubGrupos.Obtener(id);
            return PartialView("_Delete", subgrupo);
        }
    }
}