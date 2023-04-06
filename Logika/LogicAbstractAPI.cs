
using Dane; 

namespace Logika
{
    public abstract class LogicAbstractAPI
    {
        public abstract void addBall(Ball b);

        public abstract List<Ball> getBalls();

        public static LogicAbstractAPI createAPI()
        {
            return new LogicAPI();
        }
    }
    internal class LogicAPI : LogicAbstractAPI
    {
        private DataAbstractAPI dataAPI;
        public LogicAPI()
        {
            dataAPI = DataAbstractAPI.CreateAPI();
            
        }

        public void MoveBalls(int size)
        {
            foreach (var ball in dataAPI.GetBalls())
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


        public override void addBall(Ball b)
        {
           dataAPI.AddBall(b);
        }

        public override List<Ball> getBalls()
        {
            return dataAPI.GetBalls(); 
        }

  
    }
}