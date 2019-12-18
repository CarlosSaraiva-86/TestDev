using System;

namespace TesteDev
{
    class Program
    {
        static void Main(string[] args)
        {
            Credito credito = new Credito();
            Console.WriteLine("Digite o valor do credito:");
            credito.ValorCredito = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine
                ("Escolha o tipo do credito: " +
                "\n1 - Credito Direto - Taxa de 2% ao mês " +
                "\n2 - Credito Consignado - Taxa de 1 % ao mês " +
                "\n3 - Credito Pessoa Jurídica - Taxa de 5 % ao mês " +
                "\n4 - Credito Pessoa Física - Taxa de 3 % ao mês " +
                "\n5 - Credito Imobiliário - Taxa de 9 % ao ano");
            credito.TipoCredito = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a quatidade de parcelas:");
            credito.QtdeParcelas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Data do primeiro vencimento: Ex.: 01/01/2020");
            credito.DataPrimeiroVencimento = Convert.ToDateTime(Console.ReadLine());

            string msgErro = "";
            credito.Aprovado = true;
            if (credito.ValorCredito > 1000000)
            {
                msgErro += "Valor do credito não pode exeder 1 milhao\n";
                credito.Aprovado = false;
            }
            if (credito.ValorCredito < 15000 && credito.TipoCredito == 3)
            {
                msgErro += "Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00\n";
                credito.Aprovado = false;
            }
            if (credito.QtdeParcelas > 72 || credito.QtdeParcelas < 5)
            {
                msgErro += "A quantidade de parcelas máximas é de 72x e a mínima é de 5x\n";
                credito.Aprovado = false;
            }
            if (credito.DataPrimeiroVencimento < (DateTime.Now.AddDays(15)))
            {
                msgErro += "A data do primeiro vencimento sempre será no mínimo D+15\n";
                credito.Aprovado = false;
            }
            if (credito.DataPrimeiroVencimento > (DateTime.Now.AddDays(40)))
            {
                msgErro += "e no máximo, D+40 (Dia atual + 40 dias)\n";
                credito.Aprovado = false;
            }

            if (credito.Aprovado)
            {
                credito.Calcular();
                Console.WriteLine("Credito Aprovado!");
                Console.WriteLine("Valor total: " + credito.ValorTotalCredito);
                Console.WriteLine("Valor Juros: " + credito.ValorJuros);
            }
            else
            {
                Console.WriteLine("Credito reprovado");
                Console.WriteLine(msgErro);
            }

            Console.ReadLine();
        }
    }
}
