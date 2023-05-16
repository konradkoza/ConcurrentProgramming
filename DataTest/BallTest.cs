using Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Numerics;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        DataAbstractAPI api = DataAbstractAPI.CreateAPI(500, 500);

        [TestMethod]
        public void BallProperties()
        {
            api.CreateBalls(1);
            Assert.IsNotNull(api.GetBall(0).Diameter);

            Vector2 pos = api.GetBall(0).Position;
            Vector2 vel = api.GetBall(0).Velocity;

            Assert.AreNotEqual(api.GetBall(0).Position, pos);
            Assert.AreNotEqual(api.GetBall(0).Velocity, vel);
            //Vector2 pos2 = api.GetBall(0).Position;
            //api.GetBall(0).Velocity = new Vector2(0, 0);
        }

    }
}