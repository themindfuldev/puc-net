
using System.ComponentModel.DataAnnotations;

namespace Modelo.Dominio
{
    public class Cliente
    {
        public virtual long Id { set; get; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [Display(Name = "Nome")]
        public virtual string Nome { set; get; }

        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [Display(Name = "CPF")]
        public virtual string CPF { set; get; }

        [Required(ErrorMessage = "O campo RG é obrigatório!")]
        [Display(Name = "RG")]
        public virtual string RG { set; get; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório!")]
        [Display(Name = "Telefone")]
        public virtual string Telefone { set; get; }

        public Cliente()
        {
        }

        public override string ToString()
        {
            return "Id=" + Id + ", Nome=" + Nome + ", CPF=" + CPF + ", RG=" + RG + ", Telefone=" + Telefone;
        }
    }
}
