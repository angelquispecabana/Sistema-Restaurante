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
    public class TurnoController : BaseController
    {
        // GET: Turno
        public TurnoController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var lista = await _unitOfWork.Turnos.ListarAll();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.ListaCategoria = _unit.Categorias.Listar();
            //ViewData["ListaCategoria"] = _unit.Categorias.Listar();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Turno turno)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Turnos.Apertura(turno);
                return RedirectToAction("Index");
            }
            return View(turno);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unitOfWork.Turnos.Obtener(id));
        }

        [HttpGet]
        public async Task<ActionResult> Cierre(int id)
        {
            try
            {
                await _unitOfWork.Turnos.Cierre(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }
    }
}