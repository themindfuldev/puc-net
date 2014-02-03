using System.Web.Mvc;
using Modelo.Dominio;
using Visao.Models;
using Visao.ServicoCliente;
using Visao.ServicoReserva;

namespace Visao.Controllers
{ 
    public class ReservasController : Controller
    {
        private ServicoReservaClient _servicoReserva;
        private ServicoClienteClient _servicoCliente;

        public ReservasController()
        {
            _servicoReserva = new ServicoReserva.ServicoReservaClient();
            _servicoCliente = new ServicoCliente.ServicoClienteClient();
        }

        public ActionResult ConsultarDisponibilidade()
        {
            ViewBag.Title = "Reservas";
            ViewBag.Message = "Consultar disponibilidade.";

            ConfigurarCategoriasDeQuarto();

            return View();
        }

        private void ConfigurarCategoriasDeQuarto()
        {
            var categoriasDeQuarto = _servicoReserva.ObterCategoriasDeQuarto();
            ViewData["categoriasDeQuarto"] = new SelectList(categoriasDeQuarto, "Id", "Nome");
        }

        [HttpPost]
        public ActionResult ConsultarDisponibilidade(ReservaModel reserva)
        {
            ConfigurarCategoriasDeQuarto(); 
            if (ModelState.IsValid)
            {
                reserva.DataInicio = reserva.DataInicio.AddHours(12);
                reserva.DataFim = reserva.DataFim.AddHours(12);
                
                bool disponivel = _servicoReserva.ConsultarDisponibilidade(reserva.DataInicio, reserva.DataFim, reserva.IdCategoriaDeQuarto);

                if (disponivel == false)
                {
                    ViewBag.Title = "Reservas";
                    ViewBag.Message = "Consultar disponibilidade.";
                    ViewBag.Result = "Não há disponibilidade para este período nesta categoria de quarto. Favor escolher outro período/categoria.";
                    return View(reserva);
                }
                else
                {
                    var diarias = reserva.DataFim.Subtract(reserva.DataInicio).Days;

                    float valorDaDiaria = 0;
                    foreach (var categoria in _servicoReserva.ObterCategoriasDeQuarto())
                    {
                        if (categoria.Id == reserva.IdCategoriaDeQuarto)
                        {
                            valorDaDiaria = categoria.ValorDaDiaria;
                        }
                    }

                    reserva.ValorDaReserva = diarias * valorDaDiaria;
                    return RedirectToAction("ConfirmarReserva", reserva);   
                }
            }

            return View(reserva);
        }

        public ActionResult ConfirmarReserva(ReservaModel reserva)
        {
            ViewBag.Title = "Reservas";
            ViewBag.Message = "Confirmar reserva.";

            Session["reservaModel"] = reserva;

            ConfigurarCategoriasDeQuarto();

            return View(reserva);
        }

        [HttpPost]
        public ActionResult EscolherCliente()
        {
            ViewBag.Title = "Reservas";
            ViewBag.Message = "Escolher cliente.";

            return View(_servicoCliente.ObterClientes());
        }

        public ActionResult ClienteEscolhido(long id)
        {
            ReservaModel reserva = Session["reservaModel"] as ReservaModel;
            reserva.Cliente = _servicoCliente.ObterCliente(id);
            reserva.IdReserva = _servicoReserva.ReservarQuarto(reserva.DataInicio, reserva.DataFim, reserva.IdCategoriaDeQuarto, id);

            return RedirectToAction("ReservaEfetuada");
        }

         public ActionResult ReservaEfetuada()
         {
             ViewBag.Title = "Reservas";
             ViewBag.Message = "Reserva efetuada com sucesso.";

             ConfigurarCategoriasDeQuarto();
             ReservaModel reserva = Session["reservaModel"] as ReservaModel;

             return View(reserva);
         }

         //
         // GET: /Reservas/

         public ViewResult Index()
         {
             ViewBag.Title = "Reservas";
             ViewBag.Message = "Visualizar todas as reservas.";

             var servicoCliente = new ServicoCliente.ServicoClienteClient();
             ViewBag.HaClientes = servicoCliente.ObterClientes().Length > 0? true: false;

             var servicoReservas = new ServicoReserva.ServicoReservaClient();
             return View(servicoReservas.ObterReservas());
         }

         //
         // GET: /Reservas/Details/5

         public ViewResult Details(long id)
         {
             ViewBag.Title = "Reservas";
             ViewBag.Message = "Detalhar reserva.";

             var servicoReservas = new ServicoReserva.ServicoReservaClient();
             return View(servicoReservas.ObterReserva(id));
         }

         //
         // GET: /Reservas/Delete/5

         public ActionResult Delete(long id)
         {
             ViewBag.Title = "Reservas";
             ViewBag.Message = "Cancelar reserva.";

             var servicoReservas = new ServicoReserva.ServicoReservaClient();
             return View(servicoReservas.ObterReserva(id));
         }

         //
         // POST: /Reservas/Delete/5

         [HttpPost, ActionName("Delete")]
         public ActionResult DeleteConfirmed(long id)
         {
             var servicoReservas = new ServicoReserva.ServicoReservaClient();
             servicoReservas.CancelarReserva(id);
             return RedirectToAction("Index");
         }

    }
}