using System;
using System.Collections.Generic;
using Modelo.Dominio;
using Persistencia.ORM;

namespace Negocio.Servico
{
    public class ServicoOcupacao : IServicoOcupacao
    {
        public Ocupacao RegistrarCheckin(long idReserva)
        {
            Ocupacao ocupacao = null;
            var reserva = DAO.GetById("Modelo.Dominio.Reserva,Modelo", idReserva) as Reserva;

            if (reserva != null)
            {
                var quartosDisponiveis = QuartoDAO.ConsultarQuartosDisponiveis(reserva.CategoriaDeQuarto);

                if (quartosDisponiveis.Count > 0)
                {
                    Quarto quarto = quartosDisponiveis[0] as Quarto;

                    ocupacao = new Ocupacao() {DataCheckIn = DateTime.Now, Reserva = reserva, Quarto = quarto};
                    DAO.Save(ocupacao);

                    reserva.Estado = Reserva.EstadoDeReserva.Efetivada;
                    DAO.Update(reserva);

                    quarto.Estado = Quarto.EstadoDeQuarto.Ocupado;
                    DAO.Update(quarto);
                }
            }
            return ocupacao;
        }

        public Ocupacao RegistrarCheckout(long idQuarto)
        {
            Ocupacao ocupacao = OcupacaoDAO.BuscarOcupacao(idQuarto);
            ocupacao.DataCheckOut = DateTime.Now;
            var dias = CalcularDiarias(ocupacao.DataCheckIn, (DateTime)ocupacao.DataCheckOut);
            var valorDaHospedagem = dias*ocupacao.Quarto.CategoriaDeQuarto.ValorDaDiaria;
            var conta = new Conta() {Estado = Conta.EstadoDeConta.EmAberto, ValorDaHospedagem = valorDaHospedagem, ValorTotal = valorDaHospedagem};
            DAO.Save(conta);

            ocupacao.Conta = conta;
            DAO.Update(ocupacao);

            ocupacao.Quarto.Estado = Quarto.EstadoDeQuarto.EmLimpeza;
            DAO.Update(ocupacao.Quarto);

            return ocupacao;
        }

        private static int CalcularDiarias(DateTime dataCheckIn, DateTime dataCheckOut)
        {
            var horas = dataCheckOut.Subtract(dataCheckIn).Hours;
            if (horas < 24) horas = 24;
            float dias = horas/(float) 24;
            float fracaoDia = dias - (int) dias;
            if (fracaoDia > 0.5) dias++;
            return (int) dias;
        }

        public void PagarConta(Conta conta)
        {
            conta.ValorTotal = conta.ValorDaHospedagem + conta.ValorDoFrigobar + conta.ValorOutros;
            conta.Estado = Conta.EstadoDeConta.Pago;
            DAO.Update(conta);
        }

        public void RegistrarTerminoDeLimpeza(long id)
        {
            Quarto quarto = DAO.GetById("Modelo.Dominio.Quarto,Modelo", id) as Quarto;
            if (quarto != null)
            {
                quarto.Estado = Quarto.EstadoDeQuarto.Disponivel;
                DAO.Update(quarto);
            }
        }


        public IList<Quarto> ObterQuartosOcupados()
        {
            var consulta = QuartoDAO.ObterQuartosOcupados();
            var quartos = new List<Quarto>();

            foreach (var quarto in consulta)
            {
                quartos.Add(quarto as Quarto);
            }

            return quartos;
        }
       
    }
}
