using Data;
using System.Diagnostics;

namespace LogicTest
{
    [TestClass]
    public class DataAPITest
    {
        [TestMethod]
        public void CreateAPITest()
        {
            DataAbstractAPI api = DataAbstractAPI.CreateAPI(500,500);
            Assert.IsNotNull(api);
            api.CreateBalls(2);
            double posX1 = api.GetBall(0).X;
            double posY1 = api.GetBall(0).Y;
            api.GetBall(0).Velocity = -api.GetBall(0).Velocity;
            Thread.Sleep(100);
            Assert.AreNotEqual(posX1, api.GetBall(0).X);
            Assert.AreNotEqual(posY1, api.GetBall(0).Y);
        }
    }
}