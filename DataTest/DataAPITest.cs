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

            Assert.IsNotNull(api.GetBall(0));
            Assert.IsNotNull(api.GetBalls());

            /*api.RemoveBalls();
            Assert.AreEqual(api.GetBallCount(), 0);*/
        }

        [TestMethod]
        public void PropertiesTest()
        {
            DataAbstractAPI api = DataAbstractAPI.CreateAPI(500, 500);

            Assert.AreEqual(api.Width, 500);
            Assert.AreEqual(api.Height, 500);
        }
    }
}