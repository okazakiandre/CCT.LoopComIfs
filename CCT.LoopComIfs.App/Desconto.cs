namespace CCT.LoopComIfs.App
{
    public class Desconto
    {
        public int Tipo { get; set; }
        public double Percentual { get; set; }

        public bool EhPeriodico() => Tipo == 1;
        public bool EhBlackFriday() => Tipo == 3;
    }
}
