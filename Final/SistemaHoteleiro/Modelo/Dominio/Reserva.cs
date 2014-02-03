using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Dominio
{
    public class Reserva
    {
        public enum EstadoDeReserva
        {
            Ativa,
            Cancelada,
            Efetivada
        }

        [Display(Name = "Código")]
        public virtual long Id { set; get; }

        [Display(Name = "Data de início")]
        public virtual DateTime DataInicio { set; get; }

        [Display(Name = "Data de fim")]
        public virtual DateTime DataFim { set; get; }

        [Display(Name = "Estado")]
        public virtual EstadoDeReserva Estado { set; get; }

        //public virtual Ocupacao Ocupacao { set; get; }

        [Display(Name = "Categoria")]
        public virtual CategoriaDeQuarto CategoriaDeQuarto { set; get; }

        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { set; get; }

        public Reserva()
        {
        }
    }
}
