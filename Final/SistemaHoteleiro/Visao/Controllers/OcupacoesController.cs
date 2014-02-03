using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Modelo.Dominio;
using Visao.Models;

namespace Visao.Controllers
{
    public class OcupacoesController : Controller
    {
        public ActionResult RegistrarTerminoDeLimpezaDeQuarto()
        {
            ViewBag.Title = "Ocupações";
            ViewBag.Message = "Registrar término de limpeza de quarto.";

            var servicoRelatorio = new ServicoRelatorio.ServicoRelatorioClient();
            var quartos = servicoRelatorio.ObterQuartosEmLimpeza();

            return View(quartos);
        }

        public ActionResult RegistrarLimpo(long id)
        {
            ViewBag.Title = "Ocupações";
            ViewBag.Message = "Registrar término de limpeza de quarto.";

            var servicoOcupacao = new ServicoOcupacao.ServicoOcupacaoClient();
            servicoOcupacao.RegistrarTerminoDeLimpeza(id);

            return RedirectToAction("RegistrarTerminoDeLimpezaDeQuarto");
        }

        public ViewResult ListarCheckIn()
        {
            ViewBag.Title = "Ocupações";
            ViewBag.Message = "Realizar check-in.";

            var servicoReservas = new ServicoReserva.ServicoReservaClient();
            return View(servicoReservas.ObterReservasParaCheckin());
        }

        public ActionResult CheckIn(long id)
        {
            ViewBag.Title = "Ocupações";
            ViewBag.Message = "Realizar check-in.";

            var servicoOcupacao = new ServicoOcupacao.ServicoOcupacaoClient();
            var ocupacao = servicoOcupacao.RegistrarCheckin(id);

            if (ocupacao == null)
            {
                ViewBag.Result = "Não há quartos disponíveis no momento e não foi possível realizar seu checkin.";
            }

            return View(ocupacao);
        }

        public ViewResult ListarCheckOut()
        {
            ViewBag.Title = "Ocupações";
            ViewBag.Message = "Realizar check-out.";

            var servicoOcupacao = new ServicoOcupacao.ServicoOcupacaoClient();
            return View(servicoOcupacao.ObterQuartosOcupados());
        }

        public ActionResult CheckOut(long id)
        {
            var servicoOcupacao = new ServicoOcupacao.ServicoOcupacaoClient();
            var ocupacao = servicoOcupacao.RegistrarCheckout(id);

            return RedirectToAction("Pagar", ocupacao.Conta);
        }

        public ActionResult Pagar(Conta conta)
        {
            ViewBag.Title = "Ocupações";
            ViewBag.Message = "Checkout realizado com sucesso. Pagamento de conta.";

            ViewData["formasDePagamento"] = new SelectList(Enum.GetValues(typeof(FormaDePagamento)));

            return View(conta);
        }

        [HttpPost, ActionName("Pagar")] 
        public ActionResult PagarPost(Conta conta)
        {
            var servicoOcupacao = new ServicoOcupacao.ServicoOcupacaoClient();
            servicoOcupacao.PagarConta(conta);

            return RedirectToAction("ContaPaga");
        }

         public ViewResult ContaPaga()
         {
             ViewBag.Title = "Ocupações";
             ViewBag.Message = "Pagamento de conta.";
             ViewBag.Result = "Conta paga com sucesso.";
             return View();
         }
    }
}
