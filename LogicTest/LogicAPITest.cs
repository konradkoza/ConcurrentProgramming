using Logika;
using System.Diagnostics;

namespace LogicTest
{
    [TestClass]
    public class LogicAPITest
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            LogicAPI logicAPI = new LogicAPI();

            logicAPI.addBall();
            logicAPI.addBall();
            double x1 = logicAPI.getBalls().ElementAt<Ball>(0).x;
            double y1 = logicAPI.getBalls().ElementAt<Ball>(0).y;

            Thread.Sleep(200);

            Assert.AreNotEqual(x1, logicAPI.getBalls().ElementAt<Ball>(0).x);
            Assert.AreNotEqual(y1, logicAPI.getBalls().ElementAt<Ball>(0).y);


        }
    }
}