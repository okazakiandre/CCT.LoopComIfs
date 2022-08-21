using CCT.LoopComIfs.App;

namespace CCT.LoopComIfs.UnitTest
{
    [TestClass]
    public class ProdutoServiceTest
    {
        [TestMethod]
        public void DeveriaAplicarDescontoPeriodico()
        {
            var prd = new Produto
            {
                Preco = 100,
                Descontos = new List<Desconto>
                {
                    new Desconto { Tipo = 1, Percentual = 0.2 }
                }
            };
            var srv = new ProdutoService();

            var res = srv.CalcularValorDesconto(prd, "");

            Assert.AreEqual(80, res);
        }

        [TestMethod]
        public void NaoDeveriaAplicarDescontoPeriodico()
        {
            var prd = new Produto
            {
                Preco = 100,
                Descontos = new List<Desconto>
                {
                    new Desconto { Tipo = 2, Percentual = 0.2 }
                }
            };
            var srv = new ProdutoService();

            var res = srv.CalcularValorDesconto(prd, "");

            Assert.AreEqual(100, res);
        }

        [TestMethod]
        public void DeveriaAplicarDescontoBlackFriday()
        {
            var prd = new Produto
            {
                Preco = 100,
                Descontos = new List<Desconto>
                {
                    new Desconto { Tipo = 3, Percentual = 0.13 }
                }
            };
            var srv = new ProdutoService();

            var res = srv.CalcularValorDesconto(prd, "");

            Assert.AreEqual(87, res);
        }

        [TestMethod]
        public void NaoDeveriaAplicarDescontoBlackFridaySemCupom()
        {
            var prd = new Produto
            {
                Preco = 100,
                Descontos = new List<Desconto>
                {
                    new Desconto { Tipo = 2, Percentual = 0.13 }
                }
            };
            var srv = new ProdutoService();

            var res = srv.CalcularValorDesconto(prd, "");

            Assert.AreEqual(100, res);
        }

        [TestMethod]
        public void NaoDeveriaAplicarDescontoBlackFridayComCupom()
        {
            var prd = new Produto
            {
                Preco = 100,
                Descontos = new List<Desconto>
                {
                    new Desconto { Tipo = 3, Percentual = 0.13 }
                }
            };
            var srv = new ProdutoService();

            var res = srv.CalcularValorDesconto(prd, "teste");

            Assert.AreEqual(100, res);
        }

        [TestMethod]
        public void DeveriaAplicarDescontoMaximo()
        {
            var prd = new Produto
            {
                Preco = 100,
                Descontos = new List<Desconto>
                {
                    new Desconto { Tipo = 1, Percentual = 0.10 },
                    new Desconto { Tipo = 3, Percentual = 0.41 }
                }
            };
            var srv = new ProdutoService();

            var res = srv.CalcularValorDesconto(prd, "");

            Assert.AreEqual(50, res);
        }

        [TestMethod]
        public void NaoDeveriaAplicarDescontoMaximo()
        {
            var prd = new Produto
            {
                Preco = 100,
                Descontos = new List<Desconto>
                {
                    new Desconto { Tipo = 1, Percentual = 0.40 },
                    new Desconto { Tipo = 3, Percentual = 0.10 }
                }
            };
            var srv = new ProdutoService();

            var res = srv.CalcularValorDesconto(prd, "");

            Assert.AreEqual(54, res);
        }
    }
}