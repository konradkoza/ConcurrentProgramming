using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public abstract int GetBallCount();
        public abstract IBall GetBall(int index);
        public abstract void CreateBalls(int  count);
        public abstract void RemoveBalls();
        public abstract IEnumerable<IBall> GetBallsList();
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract int Diameter { get; }
        

        public static DataAbstractAPI CreateAPI(int width, int height)
        {
            return new DataAPI(width, height);
        }

        internal class DataAPI : DataAbstractAPI
        {
            public DataAPI(int width, int height)
            {
                Width = width;
                Height = height;
                _balls = new List<IBall>();
            }

            public override int Width { get; }
            public override int Height { get; }
            public override int Diameter { get; } = 40; 
            private readonly List<IBall> _balls;
            private readonly Random _random = new Random();

            public override int GetBallCount() 
            { 
                return _balls.Count;
            }

            public override IBall GetBall(int index)
            {
                return _balls[index];
            }

            public override void CreateBalls(int count)
            {
                for(int i  = 0; i < count; i++)
                {
                    var velX = _random.Next(-5, 5);
                    var velY = _random.Next(-5, 5);
                    while (velX == 0 & velY == 0)
                    {
                        velX = _random.Next(-5, 5);
                        velY = _random.Next(-5, 5);
                    }

                    var vel = new Vector2(velX, velY);
                    var ballX = _random.Next(20, Width - Diameter - 20);
                    var ballY = _random.Next(20, Height - Diameter - 20);
                    var ballMass = _random.Next(90, 250);
                    var ball = new Ball(ballX, ballY, ballMass, vel, i);
                    _balls.Add(ball);
                }
            }

            public override void RemoveBalls()
            {
                foreach(IBall ball in _balls)
                {
                    ball.Dispose();
                }
                _balls.Clear(); 
            }

            public override IEnumerable<IBall> GetBallsList()
            {
                return new ReadOnlyCollection<IBall>(_balls);
            }

        }
    }

   

}
