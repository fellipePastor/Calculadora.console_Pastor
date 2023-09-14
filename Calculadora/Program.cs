using System;
using System.IO;
using Application;
using Domain;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("5 - Sair");

            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção: ");

            short res = short.Parse(Console.ReadLine());

            switch (res)
            {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Divisao(); break;
                case 4: Multiplicacao(); break;
                case 5: Environment.Exit(0); break;
                default: Menu(); break;
            }
        }

        static void Soma()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = Operacoes.Somar(v1, v2);
            Console.WriteLine($"O resultado da soma é {resultado}");
            InserirInformacoesBd("Soma", resultado);
            SalvarUltimoComando("Soma");
            Console.ReadKey();
            Menu();
        }

        static void Subtracao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = Operacoes.Subtrair(v1, v2);
            Console.WriteLine($"O resultado da soma é {resultado}");
            InserirInformacoesBd("Subtração", resultado);
            SalvarUltimoComando("Subtração");
            Console.ReadKey();
            Menu();
        }

        static void Divisao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = Operacoes.Dividir(v1, v2);
            Console.WriteLine($"O resultado da soma é {resultado}");
            InserirInformacoesBd("Divisão", resultado);
            SalvarUltimoComando("Divisão");
            Console.ReadKey();
            Menu();
        }

        static void Multiplicacao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = Operacoes.Multiplicar(v1, v2);
            Console.WriteLine($"O resultado da soma é {resultado}");
            InserirInformacoesBd("Multiplicação", resultado);
            SalvarUltimoComando("Multiplicação");
            Console.ReadKey();
            Menu();
        }

        static void InserirInformacoesBd(
            string nomeOperacao,
            float resultado)
        {
            using (var context = new CalculadoraContext())
            {
                var novaOperacao = new OperacaoHistorico
                {
                    NomeOperacao = nomeOperacao,
                    Resultado = (decimal)resultado,
                    DataHoraOperacao = DateTime.Now
                };

                context.OperacoesHistorico.Add(novaOperacao);
                context.SaveChanges();
            }
        }
        static void SalvarUltimoComando(
            string nomeDaOperacao)
        {
            string nomeDoArquivo = "ultimo_comando.txt";
            string caminhoDoDiretorio = @"C:\ProjetosFramework\Calculadora.console_Pastor\Application";
            string caminhoDoArquivo = Path.Combine(caminhoDoDiretorio, nomeDoArquivo);

            string conteudo = $"{nomeDaOperacao} - {DateTime.Now.ToString()}";

            try
            {
                using (StreamWriter sw = File.CreateText(caminhoDoArquivo))
                {
                    sw.WriteLine(conteudo);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao criar um arquivo: {ex.Message}");
            }
        }
    }
}
