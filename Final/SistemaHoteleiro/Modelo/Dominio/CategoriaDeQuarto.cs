
namespace Modelo.Dominio
{
    public class CategoriaDeQuarto
    {
        public virtual long Id { set; get; }
        public virtual string Nome { set; get; }
        public virtual float ValorDaDiaria { set; get; }

        public CategoriaDeQuarto()
        {
        }

        public override string ToString()
        {
            return "Id=" + Id + ", Nome=" + Nome + ", ValorDaDiaria=" + ValorDaDiaria;
        }
    }
}
