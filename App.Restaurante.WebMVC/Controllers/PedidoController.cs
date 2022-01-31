using App.Restaurante.WebMVC.Models;
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
    public class PedidoController : BaseController
    {
        public PedidoController(IUnitOfWork unit) : base(unit)
        {
        }
        // GET: PedidoCabecera
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NuevoPedido()
        {
            PedidoView pedidoView = new PedidoView();
            pedidoView.Turnos = new TurnoPedido();
            pedidoView.Platos = new List<PlatoPedido>();

            Session["PedidoView"] = pedidoView;

            var listat = _unitOfWork.Turnos.ListarSinTask();
            ViewBag.IdTurno = new SelectList(listat, "IdTurno", "Descripcion");

            return View(pedidoView);
        }
        [HttpPost]
        public ActionResult NuevoPedido(PedidoView pedidoView) 
        {
            pedidoView = Session["PedidoView"] as PedidoView;
            int idturno = int.Parse(Request["IdTurno"]);
            DateTime fecha = Convert.ToDateTime(Request["Turnos.Fecha"]);
            string descripcion = Request["Turnos.Descripcion"].ToString();
            Pedido nuevoPedido = new Pedido
            {
                IdTurno = idturno,
                Descripcion = descripcion,
                Fecha = fecha,
                IdUsuario = 1
            };
            _unitOfWork.Pedidos.Crear(nuevoPedido);

            int lastPedidoId = _unitOfWork.Pedidos.UltimoId();
            foreach(PlatoPedido item in pedidoView.Platos)
            {
                var detalle = new PedidoDetalle()
                {
                    IdPedido = lastPedidoId,
                    IdPlato = item.IdPlato,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio,
                    Descuento = 0
                };
                _unitOfWork.PedidosDetalle.Crear(detalle);
            }

            pedidoView = new PedidoView();
            pedidoView.Turnos = new TurnoPedido();
            pedidoView.Platos = new List<PlatoPedido>();
            Session["PedidoView"] = pedidoView;

            var listat = _unitOfWork.Turnos.ListarSinTask();
            ViewBag.IdTurno = new SelectList(listat, "IdTurno", "Descripcion");

            return View(pedidoView);
        }

        [HttpGet]
        public ActionResult AddPlato()
        {
            var lista = _unitOfWork.Platos.ListarSinTask();
            ViewBag.IdPlato = new SelectList(lista, "IdPlato", "Descripcion");

            return PartialView("_AddPlato");
            //return View();
        }
        [HttpPost]
        public ActionResult AddPlato(PlatoPedido platoPedido)
        {
            var pedidoview = Session["PedidoView"] as PedidoView;
            var idplato = int.Parse(Request["IdPlato"]);
            Plato plato = _unitOfWork.Platos.BuscarPorIdSinTask(idplato);

            platoPedido = new PlatoPedido()
            {
                IdPlato = plato.IdPlato,
                Descripcion = plato.Descripcion,
                Precio = plato.Precio,
                Cantidad = Convert.ToDecimal(Request["Cantidad"])
            };
            pedidoview.Platos.Add(platoPedido);

            var listat = _unitOfWork.Turnos.ListarSinTask();
            ViewBag.IdTurno = new SelectList(listat, "IdTurno", "Descripcion");

            var listap = _unitOfWork.Platos.ListarSinTask();
            ViewBag.IdPlato = new SelectList(listap, "IdPlato", "Descripcion");

            return View("NuevoPedido", pedidoview);
        }
    }
}