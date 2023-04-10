

using Data;

namespace Logika
{
    public abstract class LogicAbstractAPI
    {
        public abstract void addBall();

        public abstract List<Ball> getBalls();

        public abstract void MoveBalls();


        public static LogicAbstractAPI createAPI()
        {
            return new LogicAPI();
        }
    }
    internal class LogicAPI : LogicAbstractAPI
    {
        private List<Ball> balls;

        public int size { get; set; } = 500;

        private Random random = new Random();

        private DataAbstractAPI dataAPI;

        public LogicAPI()
        {
            balls = new List<Ball>();
            dataAPI = DataAbstractAPI.CreateAPI();
        }

        public override void MoveBalls()
        {
            foreach (var ball in balls)
            {
                ball.x += ball.xSpeed;
                ball.y += ball.ySpeed;
                
                if (ball.X < 0 || ball.X + ball.Diameter > size)
                {
                    ball.xSpeed *= -1;
                }
                if (ball.Y < 0 || ball.Y + ball.Diameter > size)
                {
                    ball.ySpeed *= -1;
                }
            }
        }


        public override void addBall()
        {
            balls.Add(new Ball(random.NextDouble() * (size - 30) + 10, random.NextDouble() * (size - 30) + 10, random.NextDouble() * 2 + 1, random.NextDouble() * 2 + 1 ));
        }

        public override List<Ball> getBalls()
        {
            return balls;
        }

  
    }
}