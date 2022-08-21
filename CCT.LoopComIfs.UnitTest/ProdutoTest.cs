using CCT.LoopComIfs.App;

namespace CCT.LoopComIfs.UnitTest
{
    [TestClass]
    public class ProdutoTest
    {
        [TestMethod]
        public void DeveriaObterDescontoPeriodico()
        {
            var prd = CriarProduto();
            var res = prd.ObterDescontoPeriodico();
            Assert.AreEqual(0.1, res);
        }

        [TestMethod]
        public void NaoDeveriaObterDescontoPeriodico()
        {
            var prd = new Produto 
            { 
                Descontos = new List<Desconto> { new Desconto { Tipo = 2 } }
            };
            var res = prd.ObterDescontoPeriodico();
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void DeveriaObterDescontoBlackFridaySemCupom()
        {
            var prd = CriarProduto();
            var res = prd.ObterDescontoBlackFriday("");
            Assert.AreEqual(0.3, res);
        }

        [TestMethod]
        public void NaoDeveriaObterDescontoBlackFridaySemCupom()
        {
            var prd = new Produto
            {
                Descontos = new List<Desconto> { new Desconto { Tipo = 2 } }
            };
            var res = prd.ObterDescontoBlackFriday("");
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void NaoDeveriaObterDescontoBlackFridayComCupom()
        {
            var prd = CriarProduto();
            var res = prd.ObterDescontoBlackFriday("teste");
            Assert.AreEqual(0, res);
        }

        private Produto CriarProduto()
        {
            var prd = new Produto
            {
                Descontos = new List<Desconto>
                {
                    new Desconto { Tipo = 1, Percentual = 0.1 },
                    new Desconto { Tipo = 2, Percentual = 0.2 },
                    new Desconto { Tipo = 3, Percentual = 0.3 }
                }
            };
            return prd;
        }
    }
}