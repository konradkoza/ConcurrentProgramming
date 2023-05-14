using Logika;

namespace LogicTest
{
    [TestClass]
    public class LogicAPITest
    {
        [TestMethod]
        public void CreateAPITest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI(500,500);
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public void AddAndGetBallsTest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI(500, 500);
            Assert.AreEqual(api.GetBalls().Count, 0);
            api.AddBalls(1);
            api.AddBalls(1);
            Assert.AreEqual(api.GetBalls().Count, 2);
        }

        [TestMethod]
        public void MoveBallsTest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI(500, 500);
            api.AddBalls(1);
            Assert.AreEqual(api.GetBalls().Count, 1);
            double[] coordinates = new double[2];
            coordinates[0] = api.GetBalls()[0].X;
            coordinates[1] = api.GetBalls()[0].Y;
            //api.MoveBalls();
            //Assert.AreNotEqual(coordinates[0], api.GetBalls()[0].X);
            //Assert.AreNotEqual(coordinates[0], api.GetBalls()[0].Y);
        }
    }
}