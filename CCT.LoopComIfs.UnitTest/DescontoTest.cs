
using CCT.LoopComIfs.App;

namespace CCT.LoopComIfs.UnitTest
{
    [TestClass]
    public class DescontoTest
    {
        [TestMethod]
        public void DeveriaIndicarQueEhDescontoPeriodico()
        {
            var desc = new Desconto { Tipo = 1 };
            Assert.IsTrue(desc.EhPeriodico());
        }

        [TestMethod]
        public void NaoDeveriaIndicarQueEhDescontoPeriodico()
        {
            var desc = new Desconto { Tipo = 3 };
            Assert.IsFalse(desc.EhPeriodico());
        }

        [TestMethod]
        public void DeveriaIndicarQueEhDescontoBlackFriday()
        {
            var desc = new Desconto { Tipo = 3 };
            Assert.IsTrue(desc.EhBlackFriday());
        }

        [TestMethod]
        public void NaoDeveriaIndicarQueEhDescontoBlackFriday()
        {
            var desc = new Desconto { Tipo = 1 };
            Assert.IsFalse(desc.EhBlackFriday());
        }
    }
}