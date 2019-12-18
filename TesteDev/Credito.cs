using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDev
{
    public class Credito
    {
        public double ValorCredito { get; set; }
        public int TipoCredito { get; set; }
        public int QtdeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public bool Aprovado { get; set; }
        public double ValorTotalCredito { get; set; }
        public double ValorJuros { get; set; }

        internal void Calcular()
        {
            /*1 - Credito Direto -Taxa de 2 % ao mês
              2 - Credito Consignado - Taxa de 1 % ao mês
              3 - Credito Pessoa Jurídica -Taxa de 5 % ao mês
              4 - Credito Pessoa Física -Taxa de 3 % ao mês
              5 - Credito Imobiliário - Taxa de 9 % ao ano*/


            if (TipoCredito == 1)
                ValorTotalCredito = ValorCredito * 1.02;
            else if (TipoCredito == 2)
                ValorTotalCredito = ValorCredito * 1.01;
            else if (TipoCredito == 3)
                ValorTotalCredito = ValorCredito * 1.05;
            else if (TipoCredito == 4)
                ValorTotalCredito = ValorCredito * 1.03;
            else if (TipoCredito == 5)
                ValorTotalCredito = ValorCredito * 1.09;

            ValorJuros = ValorTotalCredito - ValorCredito;

        }
    }
}
