

namespace Modelo.Dominio
{
    public enum FormaDePagamento
    {
        Dinheiro,
        Cheque,
        CartaoDeCredito
    }

    public class Conta
    {
        public enum EstadoDeConta
        {
            Pago,
            EmAberto
        }

        public virtual long Id { set; get; }
        public virtual float ValorDaHospedagem { set; get; }
        public virtual float ValorDoFrigobar { set; get; }
        public virtual float ValorOutros { set; get; }
        public virtual float ValorTotal { set; get; }
        public virtual FormaDePagamento FormaDePagamento { set; get; }
        public virtual EstadoDeConta Estado { set; get; }

        public Conta()
        {
        }
    }
}
