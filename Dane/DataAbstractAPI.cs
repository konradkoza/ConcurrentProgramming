using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DataAbstractAPI
    {
        public DataAbstractAPI() { }

        public abstract void AddBall(Ball b);

        public abstract List<Ball> GetBalls();

        public static DataAbstractAPI CreateAPI()
        {
            return new DataAPI();
        }
    }

    internal class DataAPI : DataAbstractAPI
    {
        private List<Ball> balls;

        public DataAPI()
        {

            balls = new List<Ball>();
        }

        public override void AddBall(Ball b)
        {
            balls.Add(b);
        }

        public override List<Ball> GetBalls()
        {
            return balls;
        }

    }
}
