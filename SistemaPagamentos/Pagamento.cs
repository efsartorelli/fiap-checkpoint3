using System;

namespace SistemaPagamentos
{
    public abstract class Pagamento
    {
        public decimal Valor { get; protected set; }
        public DateTime Data { get; private set; }

        protected Pagamento(decimal valor)
        {
            Valor = valor;
            Data = DateTime.Now;
        }

        public abstract string ProcessarPagamento();
    }
}
