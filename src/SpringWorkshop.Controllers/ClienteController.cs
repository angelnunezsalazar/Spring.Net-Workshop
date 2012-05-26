using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SpringWorkshop.ApplicationServices;
using SpringWorkshop.Domain;
using MvcContrib;

namespace SpringWorkshop.Controllers
{
    public class ClienteController:Controller
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        public ActionResult Index()
        {
            IList<Cliente> clientes = clienteService.ObtenerTodos();
            return View(clientes);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            try
            {
                clienteService.Registrar(cliente);
                return this.RedirectToAction(x => x.Index());

            }
            catch (Exception)
            {
                return View(cliente);
            }
        }
    }
}
