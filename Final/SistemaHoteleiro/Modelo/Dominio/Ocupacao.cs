using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Dominio
{
    public class Ocupacao
    {
        [Display(Name = "Código")]
        public virtual long Id { set; get; }

        [Display(Name = "Data de check in")]
        public virtual DateTime DataCheckIn { set; get; }
        public virtual DateTime? DataCheckOut { set; get; }

        public virtual Conta Conta { set; get; }
        
        public virtual Reserva Reserva { set; get; }
        public virtual Quarto Quarto { set; get; }

        public Ocupacao()
        {
        }
    }
}
