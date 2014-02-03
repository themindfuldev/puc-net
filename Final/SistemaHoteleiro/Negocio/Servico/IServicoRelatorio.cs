using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using Modelo.Dominio;

namespace Negocio.Servico
{
    [ServiceContract]
    public interface IServicoRelatorio
    {
        [OperationContract]
        IList<Quarto> ObterQuartos();

        [OperationContract]
        IList<Quarto> ObterQuartosEmLimpeza();

        [OperationContract]
        IList<Quarto> ObterQuartosPorCategoria(long categoriaDeQuartoId);

        [OperationContract]
        IList<Quarto> ObterQuartosDisponiveisPorPeriodo(DateTime dataInicio, DateTime dataFinal);

        [OperationContract]
        float ObterFaturamentoPorPeriodo(DateTime dataInicio, DateTime dataFinal);
    }
}
