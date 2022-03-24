using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task0Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void addTest()
        {
            zadanie0.Calculator calculator = new zadanie0.Calculator();
            float value = calculator.add(2, 3);

            Assert.AreEqual(value, 5);
            Assert.AreNotEqual(value, 0);
        }

        [TestMethod]
        public void subTest()
        {
            zadanie0.Calculator calculator = new zadanie0.Calculator();
            float value = calculator.sub(3, 2);

            Assert.AreEqual(value, 1);
        }

        [TestMethod]
        public void mulTest()
        {
            zadanie0.Calculator calculator = new zadanie0.Calculator();
            float value = calculator.mul(3, 2);

            Assert.AreEqual(value, 6);
        }

        [TestMethod]
        public void divTest()
        {
            zadanie0.Calculator calculator = new zadanie0.Calculator();
            float value = calculator.div(9, 3);

            Assert.AreEqual(value, 3);
        }
    }
}