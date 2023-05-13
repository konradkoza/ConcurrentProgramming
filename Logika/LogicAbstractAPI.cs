

using Data;

namespace Logika
{
    public abstract class LogicAbstractAPI
    {
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }

        public abstract void AddBalls(int count);

        public abstract IEnumerable<IBall> GetBalls();
        
        public abstract void RemoveAllBalls();
        public static LogicAbstractAPI CreateAPI(int width, int height)
        {
            return new LogicAPI(width, height);
        }
    }
    internal class LogicAPI : LogicAbstractAPI
    {
        private readonly object _collisionLock = new();
        public override int Width { get; set; }
        public override int Height { get; set; }

        public int size { get; set; } = 500;

        private Random random = new Random();

        private DataAbstractAPI dataAPI;

        public LogicAPI(int width, int height)
        {
            dataAPI = DataAbstractAPI.CreateAPI(width, height);
            Width = width;
            Height = height;
        }



        public override void AddBalls(int count)
        {
            dataAPI.CreateBalls(count);
            for(int i = 0; i < count; i++)
            {
                dataAPI.GetBall(i).BallChanged += DetectBallCollision;
                dataAPI.GetBall(i).BallChanged += DetectWallCollision;
            }

        }

        public override IEnumerable<IBall> GetBalls()
        {
            return dataAPI.GetBallsList();
        }

        public override void RemoveAllBalls()
        {
            dataAPI.RemoveBalls();
        }

        private void DetectBallCollision(object? sender, EventArgs args)
        {
            lock (_collisionLock) { }
        }

        private void DetectWallCollision(object? sender, EventArgs args)
        {

        }

    }
}