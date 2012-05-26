using System.Collections.Generic;
using System.Web.Mvc;
using SpringWorkshop.ApplicationServices;
using SpringWorkshop.Domain;
using MvcContrib;

namespace SpringWorkshop.Controllers
{
    public class PedidoController:Controller
    {
        private readonly IPedidoService pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }
        
        public ActionResult Index(int idCliente)
        {
            IEnumerable<Pedido> pedidos = pedidoService.ObtenerPedidos(idCliente);
            return View(pedidos);
        }

        [HttpPost]
        public ActionResult Enviar(int idCliente)
        {
            pedidoService.EnviarPedidos(idCliente);
            return this.RedirectToAction(x => x.Index(idCliente));
        }
    }
}
