using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public abstract int GetBallCount();
        public abstract void AddBall(IBall ball);
        public abstract IBall GetBall(int index);
        public abstract void CreateBalls(int  count);
        

        public static DataAbstractAPI CreateAPI()
        {
            return new DataAPI();
        }

        internal class DataAPI : DataAbstractAPI
        {
            private readonly List<IBall> _balls;

            public override int GetBallCount() 
            { 
                return _balls.Count;
            }

            public override void AddBall(IBall ball)
            {
                _balls.Add(ball);
            }

            public override IBall GetBall(int index)
            {
                return _balls[index];
            }

            public override void CreateBalls(int count)
            {
                throw new NotImplementedException();
            }
        }
    }

   

}
