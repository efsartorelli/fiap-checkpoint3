using System;
using System.Globalization;
using System.Linq;

namespace SistemaPagamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Menu.ExibirMenu();
                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        ProcessarPagamentoCartao();
                        break;
                    case "2":
                        ProcessarPagamentoBoleto();
                        break;
                    case "3":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void ProcessarPagamentoCartao()
        {
            const int minCartao = 15;
            const int maxCartao = 16;
            string numero;

            while (true)
            {
                Console.Write($"Informe o número do cartão ({minCartao} a {maxCartao} dígitos): ");
                numero = Console.ReadLine()?.Trim() ?? "";

                if (!numero.All(char.IsDigit))
                {
                    Console.WriteLine($"Entrada '{numero}' inválida. Use apenas dígitos.");
                }
                else if (numero.Length < minCartao || numero.Length > maxCartao)
                {
                    Console.WriteLine($"Você digitou {numero.Length} caracteres. Mínimo: {minCartao}, Máximo: {maxCartao}.");
                }
                else
                {
                    break;
                }
            }

            decimal valor = LerValorPagamento();
            var pag = new PagamentoCartao(valor, numero);
            Console.WriteLine(pag.ProcessarPagamento());
        }

        private static void ProcessarPagamentoBoleto()
        {
            const int minBoleto = 47;
            const int maxBoleto = 48;
            string codigo;

            while (true)
            {
                Console.Write($"Informe o código de barras ({minBoleto} a {maxBoleto} dígitos): ");
                codigo = Console.ReadLine()?.Trim() ?? "";

                if (!codigo.All(char.IsDigit))
                {
                    Console.WriteLine($"Entrada '{codigo}' inválida. Use apenas dígitos.");
                }
                else if (codigo.Length < minBoleto || codigo.Length > maxBoleto)
                {
                    Console.WriteLine($"Você digitou {codigo.Length} caracteres. Mínimo: {minBoleto}, Máximo: {maxBoleto}.");
                }
                else
                {
                    break;
                }
            }

            decimal valor = LerValorPagamento();
            var pag = new PagamentoBoleto(valor, codigo);
            Console.WriteLine(pag.ProcessarPagamento());
        }
        private static decimal LerValorPagamento()
        {
            decimal valor;
            while (true)
            {
                Console.Write("Informe o valor do pagamento (aceita decimais): ");
                string entrada = Console.ReadLine()?.Trim() ?? "";

                if (!decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.CurrentCulture, out valor) || valor <= 0)
                {
                    Console.WriteLine($"Entrada '{entrada}' inválida. Insira um número maior que zero, podendo usar decimais.");
                }
                else
                {
                    return valor;
                }
            }
        }
    }
}
