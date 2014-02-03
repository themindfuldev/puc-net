using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Dominio
{
    public class Quarto
    {
        public enum EstadoDeQuarto
        {
            Disponivel,
            Ocupado,
            EmLimpeza,
            EmManutencao
        }

        public virtual long Id { set; get; }

        [Display(Name = "Número")]
        public virtual byte Numero { set; get; }

        [Display(Name = "Estado")]
        public virtual EstadoDeQuarto Estado { set; get; }

        [Display(Name = "Categoria")]
        public virtual CategoriaDeQuarto CategoriaDeQuarto { set; get; }

        public virtual IList<Ocupacao> Ocupacoes { set; get; }

        public Quarto()
        {
        }

        public override string ToString()
        {
            return "Id=" + Id + ", Numero=" + Numero + ", Estado=" + Estado + ", CategoriaDeQuarto={" + CategoriaDeQuarto + "}";
        }
    }
}
