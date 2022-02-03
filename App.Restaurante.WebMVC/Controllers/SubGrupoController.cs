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
            SubGrupoViewModel subGrupoViewModel = new SubGrupoViewModel();
            subGrupoViewModel.ListaGrupo = await _unitOfWork.Grupos.Listar();
            return PartialView("_Create", subGrupoViewModel);            
        }
        [HttpPost]
        public async Task<ActionResult> Create(SubGrupoViewModel subGrupoViewModel)
        {
            if (ModelState.IsValid)
            {
                SubGrupo subGrupo = SetearSubGrupo(subGrupoViewModel);
                await _unitOfWork.SubGrupos.Insertar(subGrupo);
                return RedirectToAction("Index");
            }
            subGrupoViewModel = await SetearSubGrupoViewModel(subGrupoViewModel);
            return PartialView("_Create", subGrupoViewModel);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            SubGrupoViewModel subGrupoViewModel = new SubGrupoViewModel();
            subGrupoViewModel.SubGrupo = await _unitOfWork.SubGrupos.Obtener(id);
            subGrupoViewModel.ListaGrupo = await _unitOfWork.Grupos.Listar();
            return PartialView("_Edit", subGrupoViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(SubGrupoViewModel subGrupoViewModel) {
            if (ModelState.IsValid) {
                SubGrupo subGrupo = SetearSubGrupo(subGrupoViewModel);
                await _unitOfWork.SubGrupos.Modificar(subGrupo);
                return RedirectToAction("Index");
            }
            subGrupoViewModel = await SetearSubGrupoViewModel(subGrupoViewModel);
            return PartialView("_Edit", subGrupoViewModel);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var subgrupo = await _unitOfWork.SubGrupos.Obtener(id);
            return PartialView("_Delete", subgrupo);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            if ((await _unitOfWork.SubGrupos.Eliminar(id)) != 0) return RedirectToAction("Index");

            return View(await _unitOfWork.SubGrupos.Obtener(id));
        }
        private static SubGrupo SetearSubGrupo(SubGrupoViewModel subGrupoViewModel)
        {
            SubGrupo subGrupo = new SubGrupo();
            subGrupo.IdSubGrupo = subGrupoViewModel.SubGrupo.IdSubGrupo;
            subGrupo.Descripcion = subGrupoViewModel.SubGrupo.Descripcion;
            subGrupo.IdGrupo = subGrupoViewModel.SubGrupo.IdGrupo;
            subGrupo.Estado = subGrupoViewModel.SubGrupo.Estado;
            return subGrupo;
        }
        private async Task<SubGrupoViewModel> SetearSubGrupoViewModel(SubGrupoViewModel subGrupoViewModel)
        {
            SubGrupoViewModel subGrupopost = new SubGrupoViewModel();
            subGrupopost.SubGrupo = subGrupoViewModel.SubGrupo;
            subGrupopost.ListaGrupo = await _unitOfWork.Grupos.Listar();
            return subGrupopost;
        }
    }
}