using Logika;
using Moq;
using System.Diagnostics;

namespace LogicTest
{
    [TestClass]
    public class LogicAPITest
    {
        [TestMethod]
        public void createAPITest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.createAPI();
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public void addAndGetBallsTest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.createAPI();
            Assert.AreEqual(api.getBalls().Count, 0);
            api.addBall();
            api.addBall();
            Assert.AreEqual(api.getBalls().Count, 2);
        }

        [TestMethod]
        public void moveBallsTest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.createAPI();
            api.addBall();
            Assert.AreEqual(api.getBalls().Count, 1);
            double[] coordinates = new double[2];
            coordinates[0] = api.getBalls()[0].X;
            coordinates[1] = api.getBalls()[0].Y;
            api.MoveBalls();
            Assert.AreNotEqual(coordinates[0], api.getBalls()[0].X);
            Assert.AreNotEqual(coordinates[0], api.getBalls()[0].Y);
        }
    }
}