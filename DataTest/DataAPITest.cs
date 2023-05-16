using Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        


        [TestMethod]
        public void CreateAPITest()
        {
            DataAbstractAPI api = DataAbstractAPI.CreateAPI(500, 500);
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public void BallOperationsTest()
        {
            DataAbstractAPI api = DataAbstractAPI.CreateAPI(500, 500);

            Assert.AreEqual(api.GetBallCount(), 0);
            api.CreateBalls(2);
            Assert.AreEqual(api.GetBallCount(), 2);

            IBall ball = api.GetBall(0);
            Assert.IsNotNull(ball);

            //api.RemoveBalls();
            //Assert.AreEqual(api.GetBallCount(), 0);
        }
    }
}