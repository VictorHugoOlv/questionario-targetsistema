using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using QuestionarioTargetSistemas;
using System.Drawing;



///*1) Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0;
//Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; }
//Imprimir(SOMA);
//Ao final do processamento, qual será o valor da variável SOMA?*/
Console.WriteLine("1º Questão");

int INDICE = 13, SOMA = 0, K = 0;

while (K < INDICE)
{
    K = K + 1; 
    SOMA = SOMA + K;
}
Console.WriteLine(SOMA);
Console.WriteLine(" ");

///*2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...),
///escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.

//IMPORTANTE: Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código;*/
Console.WriteLine("2º Questão");

int termos = int.Parse(Console.ReadLine());

int primeiro = 0, segundo = 1, prox;

Console.Write(primeiro + " " + segundo + " ");

for (int i = 3; i <= termos; i++)
{
    prox = primeiro + segundo;
    Console.Write(prox + " ");

    primeiro = segundo;
    segundo = prox;
}
Console.WriteLine(" ");
Console.WriteLine(" ");

///*3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
//• O menor valor de faturamento ocorrido em um dia do mês;
//• O maior valor de faturamento ocorrido em um dia do mês;
//• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

//IMPORTANTE:
//a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
//b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;*/
Console.WriteLine("3º Questão");


var faturamento = new Faturamento();
List<Registro> faturamentos = faturamento.ObterLancamentos();

    // Filtrar dias com faturamento maior que zero
var diasComFaturamento = faturamentos.Where(f => f.valor > 0).ToList();

    // Encontrar o menor e o maior valor de faturamento
double menorValor = diasComFaturamento.Min(f => f.valor);
double maiorValor = diasComFaturamento.Max(f => f.valor);

    // Calcular a média dos dias com faturamento
double mediaMensal = diasComFaturamento.Average(f => f.valor);

    // Contar os dias em que o faturamento foi superior à média mensal
int diasAcimaDaMedia = diasComFaturamento.Count(f => f.valor > mediaMensal);

    // Exibir os resultados
Console.WriteLine($"Menor valor de faturamento: {menorValor}");
Console.WriteLine($"Maior valor de faturamento: {maiorValor}");
Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
Console.WriteLine(" ");


///*4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
//• SP – R$67.836,43
//• RJ – R$36.678,66
//• MG – R$29.229,88
//• ES – R$27.165,48
//• Outros – R$19.849,53

//Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.*/
Console.WriteLine("4º Questão");

double SP = 67836.43,
       RJ = 36678.66,
       MG = 29229.88,
       ES = 27165.48,
       Outros = 19849.53,
       TotalMensal = SP + RJ + MG + ES + Outros;

ObterPorcentagem(SP, TotalMensal, "SP");
ObterPorcentagem(RJ, TotalMensal, "RJ");
ObterPorcentagem(MG, TotalMensal, "MG");
ObterPorcentagem(ES, TotalMensal, "ES");
ObterPorcentagem(Outros, TotalMensal, "Outros");

static void ObterPorcentagem(double valor, double total, string estado )
{
    double percentual = (valor / total) * 100;
    Console.WriteLine($"{estado}: {percentual:F2}%");
}

Console.WriteLine(" ");

///*5) Escreva um programa que inverta os caracteres de um string.

//IMPORTANTE:
//a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
//b) Evite usar funções prontas, como, por exemplo, reverse;*/

Console.WriteLine("5º Questão");

string input = Console.ReadLine();

string invertida = "";

for (int i = input.Length - 1; i >= 0; i--)
{
    invertida += input[i];
    Console.WriteLine(invertida);
}

Console.WriteLine("String invertida: " + invertida);