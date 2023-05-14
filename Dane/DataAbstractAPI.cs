
using System.Collections.ObjectModel;
using System.Numerics;


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
                    int diameter = _random.Next(20, 40);
                    int ballMass = diameter * 2;
                    float ballX = (float)(_random.Next(20 + diameter, Width - diameter - 20) + _random.NextDouble());
                    float ballY = (float)(_random.Next(20 + diameter, Height - diameter - 20) + _random.NextDouble());
                    
                    Ball ball = new Ball(ballX, ballY, ballMass, vel, diameter, i);
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
