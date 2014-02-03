using System.Collections.Generic;
using System.Web.Mvc;
using Modelo.Dominio;
using Visao.Models;

namespace Visao.Controllers
{
    public class RelatoriosController : Controller
    {
        public ActionResult MapaGeralDosQuartos()
        {
            ViewBag.Title = "Relatório";
            ViewBag.Message = "Mapa geral dos quartos.";

            var servicoRelatorio = new ServicoRelatorio.ServicoRelatorioClient();
            var quartos = servicoRelatorio.ObterQuartos();

            return View(quartos);
        }

        public ActionResult QuartosPorCategoria()
        {
            ViewBag.Title = "Relatório";
            ViewBag.Message = "Quartos por categoria.";

            var servicoReserva = new ServicoReserva.ServicoReservaClient();
            var categoriasDeQuarto = servicoReserva.ObterCategoriasDeQuarto();

            return View(categoriasDeQuarto);
        }

        public ActionResult QuartosPorCategoriaPartial(CategoriaDeQuarto categoriaDeQuarto)
        {
            var servicoRelatorio = new ServicoRelatorio.ServicoRelatorioClient();
            var quartos = servicoRelatorio.ObterQuartosPorCategoria(categoriaDeQuarto.Id);

            return View(quartos);
        }

        public ActionResult TodosOsQuartosEmProcessoDeLimpeza()
        {
            ViewBag.Title = "Relatório";
            ViewBag.Message = "Todos os quartos em processo de limpeza.";

            var servicoRelatorio = new ServicoRelatorio.ServicoRelatorioClient();
            var quartos = servicoRelatorio.ObterQuartosEmLimpeza();

            return View(quartos);
        }

        public ActionResult TodosOsQuartosDeUmaDeterminadaCategoria()
        {
            ViewBag.Title = "Relatório";
            ViewBag.Message = "Todos os quartos de uma determinada categoria.";

            var servicoReserva = new ServicoReserva.ServicoReservaClient();
            var categoriasDeQuarto = servicoReserva.ObterCategoriasDeQuarto();

            return View(categoriasDeQuarto);
        }

        public ViewResult TodosOsQuartosDestaCategoria(long id)
        {
            ViewBag.Title = "Relatório";
            ViewBag.Message = "Todos os quartos de uma determinada categoria.";

            var servicoRelatorio = new ServicoRelatorio.ServicoRelatorioClient();
            var quartos = servicoRelatorio.ObterQuartosPorCategoria((long)id);

            return View(quartos);
        }

        public ActionResult QuartosDisponiveisPorPeriodo(PeriodoModel periodo)
        {
            ViewBag.Title = "Relatório";
            ViewBag.Message = "Quartos disponíveis por período.";

            return View(periodo);
        }

        [HttpPost, ActionName("QuartosDisponiveisPorPeriodo")]
        public ActionResult QuartosDisponiveisPorPeriodoPost(PeriodoModel periodo)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Title = "Relatório";
                ViewBag.Message = "Quartos disponíveis por período.";

                if (periodo.DataFim < periodo.DataInicio)
                {
                    ViewBag.Result = "A data inicio deve ser menor que a data fim.";
                    return View(periodo);
                }
                else
                {
                    periodo.DataInicio = periodo.DataInicio.AddHours(12);
                    periodo.DataFim = periodo.DataFim.AddHours(12);

                    var servicoRelatorio = new ServicoRelatorio.ServicoRelatorioClient();
                    var quartos = servicoRelatorio.ObterQuartosDisponiveisPorPeriodo(periodo.DataInicio, periodo.DataFim);

                    periodo.Quartos = new List<Quarto>();

                    foreach (var quarto in quartos)
                    {
                        periodo.Quartos.Add(quarto as Quarto);
                    }

                    return View(periodo);
                }
            }

            return View(periodo);
        }

        public ActionResult FaturamentoDoHotelPorPeriodo()
        {
            ViewBag.Title = "Relatório";
            ViewBag.Message = "Faturamento do hotel por período.";

            return View();
        }

        [HttpPost]
        public ActionResult FaturamentoDoHotelPorPeriodo(PeriodoModel periodo)
        {
                if (periodo.DataFim < periodo.DataInicio)
                {
                    ViewBag.Title = "Relatório";
                    ViewBag.Message = "Faturamento do hotel por período.";
                    ViewBag.Result = "A data inicio deve ser menor que a data fim.";
                    return View(periodo);
                }
                else
                {
                    periodo.DataInicio = periodo.DataInicio.AddHours(12);
                    periodo.DataFim = periodo.DataFim.AddHours(12);

                    var servicoRelatorio = new ServicoRelatorio.ServicoRelatorioClient();
                    periodo.Faturamento = servicoRelatorio.ObterFaturamentoPorPeriodo(periodo.DataInicio, periodo.DataFim);

                    return RedirectToAction("ExibirFaturamentoDoHotelPorPeriodo", periodo);
                }

            return View(periodo);
        }

        public ActionResult ExibirFaturamentoDoHotelPorPeriodo(PeriodoModel periodo)
        {
            ViewBag.Title = "Relatório";
            ViewBag.Message = "Faturamento do hotel por período.";

            return View(periodo);
        }

    }
}
