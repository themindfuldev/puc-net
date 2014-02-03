using System;
using System.ComponentModel.DataAnnotations;
using Modelo.Dominio;

namespace Visao.Models
{
    public class ReservaModel
    {
        [Required(ErrorMessage = "O campo Data de início é obrigatório!")]
        [Display(Name = "Data de início")]
        public virtual DateTime DataInicio { set; get; }

        [Required(ErrorMessage = "O campo Data de fim é obrigatório!")]
        [Display(Name = "Data de fim")]
        public virtual DateTime DataFim { set; get; }

        [Required(ErrorMessage = "O campo Categoria de Quarto é obrigatório!")]
        [Display(Name = "Categoria de Quarto")]
        public virtual long IdCategoriaDeQuarto { set; get; }

        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { set; get; }

        [Display(Name = "Código da reserva")]
        public virtual long IdReserva { set; get; }

        [Display(Name = "Valor da reserva")]
        public virtual float ValorDaReserva { set; get; }

    }
}