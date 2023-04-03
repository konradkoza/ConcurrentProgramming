using Logika;

namespace LogicTest
{
    [TestClass]
    public class LogicAPITest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Ball ball1 = new Ball(20, 20);
            Ball ball2 = new Ball(30, 40);
            LogicAPI logicAPI = new LogicAPI();

            logicAPI.addBall(ball1);
            logicAPI.addBall(ball2);
            Thread.Sleep(200);
            Assert.AreNotEqual(ball1.x, 20);
            Assert.AreNotEqual(ball1.y, 20);
            Assert.AreNotEqual(ball1.x, 30);
            Assert.AreNotEqual(ball1.y, 40);

        }
    }
}