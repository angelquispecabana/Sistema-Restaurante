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
    public class GrupoController : BaseController
    {
        public GrupoController(IUnitOfWork unit) : base(unit)
        {
        }
        // GET: Grupo
        public async Task<ActionResult> Index()
        {
            var listagrupos = await _unitOfWork.Grupos.Listar();
            return View(listagrupos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public async Task<ActionResult> Create(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Grupos.Insertar(grupo);
                return RedirectToAction("Index");
            }
            return PartialView(grupo);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var grupo = await _unitOfWork.Grupos.Obtener(id);
            return PartialView("_Edit", grupo);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Grupos.Modificar(grupo);
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", grupo);
        }
    }
}