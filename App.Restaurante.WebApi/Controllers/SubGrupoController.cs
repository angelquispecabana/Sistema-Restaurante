using App.Restaurante.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace App.Restaurante.WebApi.Controllers
{
    public class SubGrupoController : BaseController
    {
        public SubGrupoController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetList()
        {
            return Ok(await _unit.SubGrupos.Listar(""));
        }
    }
}