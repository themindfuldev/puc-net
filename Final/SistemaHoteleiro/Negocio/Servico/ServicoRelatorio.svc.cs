using System;
using System.Collections;
using System.Collections.Generic;
using Modelo.Dominio;
using Persistencia.ORM;

namespace Negocio.Servico
{
    public class ServicoRelatorio : IServicoRelatorio
    {
        private ServicoReserva _servicoReserva;

        public ServicoRelatorio()
        {
            _servicoReserva = new ServicoReserva();
        }

        public IList<Quarto> ObterQuartos()
        {
            var consulta = DAO.GetAllInOrder("Modelo.Dominio.Quarto,Modelo", "Numero");
            var quartos = new List<Quarto>();

            foreach (var quarto in consulta)
            {
                quartos.Add(quarto as Quarto);
            }

            return quartos;
        }

        public IList<Quarto> ObterQuartosEmLimpeza()
        {
            var consulta = QuartoDAO.ObterQuartosEmLimpeza();
            var quartos = new List<Quarto>();

            foreach (var quarto in consulta)
            {
                quartos.Add(quarto as Quarto);
            }

            return quartos;
        }

        public IList<Quarto> ObterQuartosPorCategoria(long categoriaDeQuartoId)
        {
            var consulta = QuartoDAO.ObterQuartosPorCategoria(categoriaDeQuartoId);
            var quartos = new List<Quarto>();

            foreach (var quarto in consulta)
            {
                quartos.Add(quarto as Quarto);
            }

            return quartos;
        }

        public IList<Quarto> ObterQuartosDisponiveisPorPeriodo(DateTime dataInicio, DateTime dataFinal)
        {
            var quartosDisponiveis = new List<Quarto>();

            var categoriasDeQuarto = _servicoReserva.ObterCategoriasDeQuarto();
            foreach (var categoriaDeQuarto in categoriasDeQuarto)
            {
                var reservas = ReservaDAO.ConsultarReservas(dataInicio, dataFinal, categoriaDeQuarto as CategoriaDeQuarto);
                var quartos = QuartoDAO.ConsultarQuartosDisponiveis(categoriaDeQuarto as CategoriaDeQuarto);

                for (int i = 0; i < reservas.Count; i++)
                {
                    quartos.RemoveAt(0);
                }

                foreach (var quarto in quartos)
                {
                    quartosDisponiveis.Add(quarto as Quarto);
                }
                
            }

            return quartosDisponiveis;
        }

        public float ObterFaturamentoPorPeriodo(DateTime dataInicio, DateTime dataFinal)
        {
            return OcupacaoDAO.ObterFaturamentoPorPeriodo(dataInicio, dataFinal);
        }
    }
}
