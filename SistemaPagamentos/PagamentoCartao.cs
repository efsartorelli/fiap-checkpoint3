using System;
using System.Linq;

namespace SistemaPagamentos
{
    public class PagamentoCartao : Pagamento
    {
        public string NumeroCartao { get; private set; }

        public PagamentoCartao(decimal valor, string numeroCartao)
            : base(valor)
        {
            NumeroCartao = numeroCartao;
        }

        public override string ProcessarPagamento()
        {
            string formatado = FormatarCartao(NumeroCartao);
            return $"Processando pagamento de R$ {Valor:F2} via Cartão (Número: {formatado}) na data {Data:dd/MM/yyyy}.";
        }

        private string FormatarCartao(string numero)
        {
            // Insere '-' a cada 4 caracteres
            return string.Concat(
                numero
                    .Select((c, i) => (i > 0 && i % 4 == 0)
                        ? "-" + c
                        : c.ToString()
                    )
            );
        }
    }
}
