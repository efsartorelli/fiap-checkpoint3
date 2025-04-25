# SistemaPagamentos

Uma aplicação de console em C# que simula o processamento de pagamentos via **Cartão** ou **Boleto**.

## Funcionalidades principais

- **Menu interativo**: Exibe opções de pagamento e permite navegar entre elas até a opção **Sair**.
- **Validação de entrada**:
  - Número do cartão: somente dígitos, entre 15 e 16 caracteres.
  - Código de barras do boleto: somente dígitos, entre 47 e 48 caracteres.
  - Valor do pagamento: aceita decimais e exige valor positivo (> 0).
- **Formatação de saída**:
  - Cartão: separa os números em blocos de 4 dígitos com `-` (ex.: `1234-5678-9012-3456`).
  - Boleto: exibe a linha digitável no padrão `XXXXX.XXXXX XXXXX.XXXXXX XXXXX.XXXXXX X XXXXXXXXXXXXXX`.
- **Processamento simulado**: Método `ProcessarPagamento()` retorna mensagem detalhada com valor, tipo, número formatado e data atual.

## Pré-requisitos

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (ou SDK CLI) configurado para C#

## Como usar

1. Clone este repositório:
   ```bash
   git clone https://github.com/SeuUsuario/SistemaPagamentos.git
   cd SistemaPagamentos
   ```
2. Abra no Visual Studio ou use o terminal:
   ```bash
   dotnet build
   dotnet run
   ```
3. No console, escolha uma opção:
   ```
   ***** Sistema de Processamento de Pagamentos *****
   ********** Escolha a forma de pagamento **********
   1 - Cartão
   2 - Boleto
   3 - Sair
   ```
4. Siga as instruções para informar número, código ou valor. Se houver erro, o sistema exibirá o problema e pedirá nova tentativa.

## Exemplo de execução

```text
Informe o número do cartão (15 a 16 dígitos): 1234567890123456
Informe o valor do pagamento (aceita decimais): 150,50
Processando pagamento de R$ 150,50 via Cartão (Número: 1234-5678-9012-3456) na data 25/04/2025.
```

## Estrutura do projeto

- `Program.cs`: fluxo principal, menu e validações de entrada.
- `Menu.cs`: classe estática para exibição do menu.
- `Pagamento.cs`: classe abstrata base com propriedade `Valor` e método `ProcessarPagamento()`.
- `PagamentoCartao.cs` e `PagamentoBoleto.cs`: implementações concretas, cada uma com sua lógica de formatação.

---

Desenvolvido para fins de aprendizado de Programação Orientada a Objetos em C#.
