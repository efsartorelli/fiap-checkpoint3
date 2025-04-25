using System;
using System.Linq;

namespace SistemaPagamentos
{
    public class PagamentoBoleto : Pagamento
    {
        public string CodigoBarras { get; private set; }

        public PagamentoBoleto(decimal valor, string codigoBarras)
            : base(valor)
        {
            CodigoBarras = codigoBarras;
        }

        public override string ProcessarPagamento()
        {
            string formatado = FormatarCodigoBarras(CodigoBarras);
            return $"Processando pagamento de R$ {Valor:F2} via Boleto (Cod Barra: {formatado}) na data {Data:dd/MM/yyyy}.";
        }

        private string FormatarCodigoBarras(string codigo)
        {
            if (codigo.Length < 47)
                return codigo;

            var p1 = codigo.Substring(0, 5) + "." + codigo.Substring(5, 5);
            var p2 = codigo.Substring(10, 5) + "." + codigo.Substring(15, 6);
            var p3 = codigo.Substring(21, 5) + "." + codigo.Substring(26, 6);
            var p4 = codigo.Substring(32, 1);
            var p5 = codigo.Substring(33); 

            return $"{p1} {p2} {p3} {p4} {p5}";
        }
    }
}
