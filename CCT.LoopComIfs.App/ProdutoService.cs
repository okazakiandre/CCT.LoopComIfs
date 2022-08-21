namespace CCT.LoopComIfs.App
{
    public class ProdutoService
    {
        private const double DESCONTO_MAXIMO = 0.5;

        public double CalcularValorDesconto (Produto prod, string cupom)
        {
            var valorFinal = prod.Preco;

            var descontoTotal = 0.0;
            foreach (var desc in prod.Descontos)
            {
                if (desc.Tipo == 1)
                {
                    valorFinal *= (1 - desc.Percentual);
                    descontoTotal += desc.Percentual;
                }
                if (desc.Tipo == 3 && 
                    string.IsNullOrWhiteSpace(cupom))
                {
                    valorFinal *= (1 - desc.Percentual);
                    descontoTotal += desc.Percentual;
                }
            }

            if (descontoTotal > DESCONTO_MAXIMO)
            {
                valorFinal = prod.Preco * DESCONTO_MAXIMO;
            }

            return valorFinal;
        }
    }
}
