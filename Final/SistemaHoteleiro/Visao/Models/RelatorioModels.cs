using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Modelo.Dominio;

namespace Visao.Models
{
    public class PeriodoModel
    {
        private string _dataInicioString;

        [Required(ErrorMessage = "O campo Data de início é obrigatório!")] 
        [Display(Name = "Data de início")] 
        public string DataInicioString
        {
            set
            {
                _dataInicioString = value;

                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("pt-BR", true);
                DataInicio = DateTime.ParseExact(value, "dd/MM/yyyy", theCultureInfo);
            }
            get
            {
                return _dataInicioString;
            }
        }

        private string _dataFimString;

        [Required(ErrorMessage = "O campo Data de fim é obrigatório!")] 
        [Display(Name = "Data de fim")]
        public string DataFimString
        { 
            set
            {
                _dataFimString = value;

                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("pt-BR", true);
                DataFim = DateTime.ParseExact(value, "dd/MM/yyyy", theCultureInfo);
            }
            get
            {
                return _dataFimString;
            }
        }

        public float Faturamento { set; get; }

        public virtual List<Quarto> Quartos { set; get; }

        public DateTime DataInicio { set; get; }

        public DateTime DataFim { set; get; }
    }

}