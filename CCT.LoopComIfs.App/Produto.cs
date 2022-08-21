namespace CCT.LoopComIfs.App
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }   
        public List<Desconto> Descontos { get; set; }

        public double ObterDescontoPeriodico()
        {
            var desc = Descontos.FirstOrDefault(d => d.EhPeriodico());
            if (desc is not null)
            {
                return desc.Percentual;
            }
            return 0;
        }

        public double ObterDescontoBlackFriday(string cupom)
        {
            var desc = Descontos.FirstOrDefault(d =>
                           d.EhBlackFriday() &&
                           string.IsNullOrWhiteSpace(cupom)
                       );
            if (desc is not null)
            {
                return desc.Percentual;
            }
            return 0;
        }
    }
}
