using System;
using System.Collections.Generic;
using System.Web;
using Modelo.Dominio;
using Persistencia.ORM;

namespace Negocio.Servico
{
    public class ServicoReserva : IServicoReserva
    {
        private ServicoCliente _servicoCliente;

        public ServicoReserva()
        {
            _servicoCliente = new ServicoCliente();
            System.Net.ServicePointManager.Expect100Continue = false;
        }

        public IList<CategoriaDeQuarto> ObterCategoriasDeQuarto()
        {
            var consulta = DAO.GetAll("Modelo.Dominio.CategoriaDeQuarto,Modelo");
            var categoriasDeQuarto = new List<CategoriaDeQuarto>();

            foreach (var categoriaDeQuarto in consulta)
            {
                categoriasDeQuarto.Add(categoriaDeQuarto as CategoriaDeQuarto);
            }

            return categoriasDeQuarto;
        }

        private CategoriaDeQuarto ObterCategoriaDeQuarto(long id)
        {
            return DAO.GetById("Modelo.Dominio.CategoriaDeQuarto,Modelo", id) as CategoriaDeQuarto;
        }

        public bool ConsultarDisponibilidade(DateTime dataInicio, DateTime dataFim, long idCategoriaDeQuarto)
        {
            bool disponivel = false;

            if (dataInicio > DateTime.Now && dataInicio < dataFim)
            {
                var categoriaDeQuarto = ObterCategoriaDeQuarto(idCategoriaDeQuarto);
                var reservas = ReservaDAO.ConsultarReservas(dataInicio, dataFim, categoriaDeQuarto);
                var quartos = QuartoDAO.ConsultarQuartosEmOrdem(categoriaDeQuarto);

                if (reservas.Count < quartos.Count)
                {
                    disponivel = true;
                }
            }

            return disponivel;
        }

        public long ReservarQuarto(DateTime dataInicio, DateTime dataFim, long idCategoriaDeQuarto, long idCliente)
        {
            var cliente = _servicoCliente.ObterCliente(idCliente);
            var categoriaDeQuarto = ObterCategoriaDeQuarto(idCategoriaDeQuarto);

            var reserva = new Reserva() { Estado = Reserva.EstadoDeReserva.Ativa, Cliente = cliente, DataInicio = dataInicio, DataFim = dataFim, CategoriaDeQuarto = categoriaDeQuarto };
            DAO.Save(reserva);
            return reserva.Id;
        }

        public IList<Reserva> ConsultarReservas(long idCliente)
        {
            var cliente = _servicoCliente.ObterCliente(idCliente);
            var consulta = ReservaDAO.ConsultarReservas(cliente);
            var reservas = new List<Reserva>();

            foreach (var reserva in consulta)
            {
                reservas.Add(reserva as Reserva);
            }

            return reservas;
        }

        public void CancelarReserva(long idReserva)
        {
            var reserva = DAO.GetById("Modelo.Dominio.Reserva,Modelo", idReserva) as Reserva;

            if (reserva != null)
            {
                reserva.Estado = Reserva.EstadoDeReserva.Cancelada;
                DAO.Update(reserva);
            }
        }

        public IList<Reserva> ObterReservas() 
        {
            NormalizarReservas();

            var consulta = DAO.GetAll("Modelo.Dominio.Reserva,Modelo");
            var reservas = new List<Reserva>();

            foreach (var reserva in consulta)
            {
                reservas.Add(reserva as Reserva);
            }

            return reservas;
        }

        private void NormalizarReservas()
        {
            var reservasVencidas = ReservaDAO.ObterReservasVencidas();
            foreach (Reserva reserva in reservasVencidas)
            {
                reserva.Estado = Reserva.EstadoDeReserva.Cancelada;
                DAO.Update(reserva);
            }

        }

        public Reserva ObterReserva(long idReserva)
        {
            return DAO.GetById("Modelo.Dominio.Reserva,Modelo", idReserva) as Reserva;
        }


        public IList<Reserva> ObterReservasParaCheckin()
        {
            NormalizarReservas();

            var consulta = ReservaDAO.ObterReservasParaCheckin();
            var reservas = new List<Reserva>();

            foreach (var reserva in consulta)
            {
                reservas.Add(reserva as Reserva);
            }

            return reservas;
        }
    }
}
