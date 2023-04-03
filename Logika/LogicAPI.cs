namespace Logika
{
    public class LogicAPI

    {
        public LogicAPI()
        {
            timer = new Timer(moveBalls, null, TimeSpan.Zero , TimeSpan.FromMilliseconds(playingField.interval));
        }

        private void moveBalls(object? state)
        {
            playingField.moveBalls();
        }

        private Timer timer;

        private Random random = new Random();

        private PlayingField playingField = new PlayingField();

        public void addBall(Ball ball)
        {
            playingField.addBall(ball);
        }

        public List<Ball> getBalls()
        {
            return playingField.getBalls(); 
        }


        public void Dispose()
        {
            timer.Dispose();
        }
    }
}