namespace CCT.LoopComIfs.App
{
    public class ProdutoServiceRefat
    {
        private const double DESCONTO_MAXIMO = 0.5;

        public double CalcularValorDesconto (Produto prod, string cupom)
        {
            var valorFinal = prod.Preco;

            var descTotal = 0.0;
            var descPeriodico = prod.Descontos
                                    .FirstOrDefault(d => d.Tipo == 1);
            if (descPeriodico is not null)
            {
                valorFinal *= (1 - descPeriodico.Percentual);
                descTotal += descPeriodico.Percentual;
            }

            var descBlackFriday = prod.Descontos
                                      .FirstOrDefault(d => 
                                          d.Tipo == 3 &&
                                          string.IsNullOrWhiteSpace(cupom)
                                      );
            if (descBlackFriday is not null)
            {
                valorFinal *= (1 - descBlackFriday.Percentual);
                descTotal += descBlackFriday.Percentual;
            }

            if (descTotal > DESCONTO_MAXIMO)
            {
                valorFinal = prod.Preco * DESCONTO_MAXIMO;
            }

            return valorFinal;
        }

        public double CalcularValorDescontoRefat(Produto prod, string cupom)
        {
            var valorFinal = prod.Preco;

            var descPeriodico = prod.ObterDescontoPeriodico();
            if (descPeriodico > 0)
            {
                valorFinal *= (1 - descPeriodico);
            }

            var descBlackFriday = prod.ObterDescontoBlackFriday(cupom);
            if (descBlackFriday > 0)
            {
                valorFinal *= (1 - descBlackFriday);
            }

            var descTotal = descPeriodico + descBlackFriday;
            if (descTotal > DESCONTO_MAXIMO)
            {
                valorFinal = prod.Preco * DESCONTO_MAXIMO;
            }

            return valorFinal;
        }
    }
}
