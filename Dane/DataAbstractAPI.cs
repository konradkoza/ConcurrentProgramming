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

        public abstract ObservableCollection<IBall> GetBalls();


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
                _balls = new ObservableCollection<IBall>();
            }
            private ObservableCollection<IBall> _balls;
            public override int Width { get; }
            public override int Height { get; }
            public override int Diameter { get; } = 40; 

            private readonly Random _random = new Random();

            public override ObservableCollection<IBall> GetBalls() => _balls;

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
                    float velX = (float)((_random.NextDouble() - 0.5) * 8);
                    float velY = (float)((_random.NextDouble() - 0.5) * 8);
                    while (velX == 0 & velY == 0)
                    {
                        velX = _random.Next(-2, 2);
                        velY = _random.Next(-2, 2);
                    }

                    Vector2 vel = new Vector2(velX, velY);
              
                    float ballX = (float)(_random.Next(20 + Diameter, Width - Diameter - 20) + _random.NextDouble());
                    float ballY = (float)(_random.Next(20 + Diameter, Height - Diameter - 20) + _random.NextDouble());
                    int ballMass = _random.Next(90, 250);
                    Ball ball = new Ball(ballX, ballY, ballMass, vel, Diameter, i);
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

           

        }
    }

   

}
