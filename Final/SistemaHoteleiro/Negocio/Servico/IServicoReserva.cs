using System;
using System.Collections.Generic;
using System.ServiceModel;
using Modelo.Dominio;

namespace Negocio.Servico
{
    [ServiceContract]
    public interface IServicoReserva
    {
        [OperationContract]
        IList<CategoriaDeQuarto> ObterCategoriasDeQuarto();

        [OperationContract]
        bool ConsultarDisponibilidade(DateTime dataInicio, DateTime dataFim, long idCategoriaDeQuarto);

        [OperationContract]
        long ReservarQuarto(DateTime dataInicio, DateTime dataFim, long idCategoriaDeQuarto, long idCliente);

        [OperationContract]
        IList<Reserva> ConsultarReservas(long idCliente);

        [OperationContract]
        IList<Reserva> ObterReservas();

        [OperationContract]
        IList<Reserva> ObterReservasParaCheckin();

        [OperationContract]
        Reserva ObterReserva(long idReserva);

        [OperationContract]
        void CancelarReserva(long idReserva);

    }
}
