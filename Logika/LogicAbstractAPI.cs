
using Dane; 

namespace Logika
{
    public abstract class LogicAbstractAPI
    {
        public abstract void addBall();

        public abstract List<Ball> getBalls();

        public static LogicAPI createAPI()
        {
            return new LogicAPI();
        }
    }
    internal class LogicAPI : LogicAbstractAPI

    {
        private DataApi dataAPI;
        public LogicAPI()
        {
            dataAPI = new DataApi();
            timer = new Timer(moveBalls, null, TimeSpan.Zero , TimeSpan.FromMilliseconds(playingField.interval));
        }

        private void moveBalls(object? state)
        {
            playingField.moveBalls();
        }

        private Timer timer;

        Random random = new Random();

        private PlayingField playingField = new PlayingField();

        public override void addBall()
        {
            playingField.addBall(new Ball(random.NextDouble() * (playingField.size - 20) + 10, random.NextDouble() * (playingField.size - 20) + 10));
        }

        public override List<Ball> getBalls()
        {
            return playingField.balls; 
        }


    }
}