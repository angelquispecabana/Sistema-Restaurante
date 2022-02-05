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

        [HttpGet]
        public async Task<ActionResult> Pagar(int id)
        {
            Venta venta = new Venta();
            venta.IdPedido = id;

            var listatd = await _unitOfWork.TiposDocumento.ListarAll();
            ViewBag.IdTipoDocumento = new SelectList(listatd, "IdTipoDocumento", "Descripcion");

            var listacl = await _unitOfWork.Clientes.ListarAll();
            ViewBag.IdCliente = new SelectList(listacl, "IdCliente", "Descripcion");

            var listamp = await _unitOfWork.MediosPago.ListarAll();
            ViewBag.IdMedioPago = new SelectList(listamp, "IdMedioPago", "Descripcion");

            return PartialView("_Pagar", venta);
        }
        [HttpPost]
        public async Task<ActionResult> Pagar(Venta venta)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Ventas.Pagar(venta);
                return RedirectToAction("Index", "Pedido");
            }
            else
            {
                return PartialView(venta);
            }

        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string desde = DateTime.Now.ToString("yyyy-MM-dd");
            string hasta = DateTime.Now.ToString("yyyy-MM-dd");
            var lista = await _unitOfWork.Pedidos.ListarAll(desde, hasta);
            return View(lista);

        }
        public async Task<PartialViewResult> ListByFilters(string desde, string hasta)
        {
            var lst = await _unitOfWork.Pedidos.ListarAll(desde, hasta);

            return PartialView("_List", lst);
        }

        [HttpGet]
        public async Task<ActionResult> NuevoPedido()
        {
            PedidoView pedidoView = new PedidoView();
            pedidoView.Turnos = new TurnoPedido();
            pedidoView.Platos = new List<PlatoPedido>();

            Session["PedidoView"] = pedidoView;

            var listat = await _unitOfWork.Turnos.ListarAll();
            ViewBag.IdTurno = new SelectList(listat, "IdTurno", "Descripcion");

            return View(pedidoView);
        }
        [HttpPost]
        public async Task<ActionResult> NuevoPedido(PedidoView pedidoView)
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
            await _unitOfWork.Pedidos.Crear(nuevoPedido);

            int lastPedidoId = _unitOfWork.Pedidos.UltimoId();
            foreach (PlatoPedido item in pedidoView.Platos)
            {
                var detalle = new PedidoDetalle()
                {
                    IdPedido = lastPedidoId,
                    IdPlato = item.IdPlato,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio,
                    Descuento = 0
                };
                await _unitOfWork.PedidosDetalle.Crear(detalle);
            }

            pedidoView = new PedidoView();
            pedidoView.Turnos = new TurnoPedido();
            pedidoView.Platos = new List<PlatoPedido>();
            Session["PedidoView"] = pedidoView;

            var listat = await _unitOfWork.Turnos.ListarAll();
            ViewBag.IdTurno = new SelectList(listat, "IdTurno", "Descripcion");

            return View(pedidoView);
        }

        [HttpGet]
        public async Task<ActionResult> AddPlato()
        {
            var lista = await _unitOfWork.Platos.Listar();
            ViewBag.IdPlato = new SelectList(lista, "IdPlato", "Descripcion");

            return PartialView("_AddPlato");
            //return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddPlato(PlatoPedido platoPedido)
        {
            var pedidoview = Session["PedidoView"] as PedidoView;
            var idplato = int.Parse(Request["IdPlato"]);
            Plato plato = await _unitOfWork.Platos.BuscarPorCodigo(idplato);

            platoPedido = new PlatoPedido()
            {
                IdPlato = plato.IdPlato,
                Descripcion = plato.Descripcion,
                Precio = plato.Precio,
                Cantidad = Convert.ToDecimal(Request["Cantidad"])
            };
            pedidoview.Platos.Add(platoPedido);

            var listat = await _unitOfWork.Turnos.ListarAll();
            ViewBag.IdTurno = new SelectList(listat, "IdTurno", "Descripcion");

            var listap = await _unitOfWork.Platos.Listar();
            ViewBag.IdPlato = new SelectList(listap, "IdPlato", "Descripcion");

            return View("NuevoPedido", pedidoview);
        }
        //[HttpGet]
        //public async Task<ActionResult> Pagar(int idPedido)
        //{
        //    try
        //    {
        //        await _unitOfWork.Pedidos.Pagar(idPedido);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}
    }
}