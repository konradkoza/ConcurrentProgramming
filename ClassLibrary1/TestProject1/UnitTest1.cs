namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClassLibrary1.Kalkulator calc = new ClassLibrary1.Kalkulator();
            int x = 5;
            int y = 6;
            Assert.AreEqual(calc.Dodaj(x, y), 11);
        }
    }
}