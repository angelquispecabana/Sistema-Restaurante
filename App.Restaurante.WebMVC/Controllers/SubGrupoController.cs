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
            return View(await _unitOfWork.SubGrupos.Listar());
        }
    }
}