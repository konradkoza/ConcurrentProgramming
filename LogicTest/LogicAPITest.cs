using Data;
using System.Collections.ObjectModel;
using System.Numerics;
using Logika;

namespace LogicTest
{
    internal class BallTest : IBall
    {
        private Task task;

        private bool _move = true;

        private int _diameter;

        public BallTest(float x, float y, int mass, Vector2 velocity, int diameter, int id)
        {
            Id = id;
            _position = new Vector2(x, y);
            _velocity = velocity;
            _diameter = diameter;
            Mass = mass;
            task = Task.Run(Move);
        }

        public event EventHandler? BallChanged;

        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;

            private set
            {
                _position = value;
            }
        }

        private Vector2 _velocity;

        public Vector2 Velocity
        {
            get => _velocity;
            set
            {

                _velocity = value;

            }
        }

        public int Diameter
        {
            get => _diameter;
        }

        public float X => _position.X;

        public float Y => _position.Y;

        public int Mass { get; }


        public int Id { get; }

        private async void Move()
        {
            while (_move)
            {
                Position += _velocity;

                BallChanged?.Invoke(this, EventArgs.Empty);
                float delay = 20 / _velocity.Length();
                await Task.Delay((int)delay);
            }

        }

        public void Dispose()
        {
            _move = false;
            task.Dispose();
        }
    }

    internal class DataAPITest : DataAbstractAPI
    {
        public DataAPITest(int width, int height)
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
            return 0;
        }

        public override IBall GetBall(int index)
        {
            return _balls[index];
        }

        public override void CreateBalls(int count)
        {
            for (int i = 0; i < count; i++)
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

                BallTest ball = new BallTest(ballX, ballY, ballMass, vel, diameter, i);
                _balls.Add(ball);
            }
        }

        public override void RemoveBalls()
        {
            foreach (IBall ball in _balls)
            {
                ball.Dispose();
            }
            _balls.Clear();
        }



    }

    [TestClass]
    public class LogicAPITest
    {
        [TestMethod]
        public void CreateAPITest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI(500,500, new DataAPITest(500, 500));
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public void CollisionsTest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI(500, 500, new DataAPITest(500, 500));

            api.AddBalls(10);
            
            Vector2[] vels = new Vector2[10];
            for(int i=0; i < 10; i++)
            {
                vels[i] = api.GetBalls()[i].Velocity;
            }
            bool hit = false;
            while (!hit)
            {
                for (int i = 0; i < api.GetBallsCount(); i++)
                {
                    if (api.GetBalls()[i].Velocity != vels[i]) { hit = true; break; }
                }
            }
            Assert.IsTrue(hit);

        }

        [TestMethod]
        public void ParametersTest() {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI(500, 500, new DataAPITest(500, 500));

            Assert.AreEqual(api.Width, 500);
            Assert.AreEqual(api.Height, 500);
            api.Width = 600;
            api.Height = 600;
            Assert.AreEqual(api.Width, 600);
            Assert.AreEqual(api.Height, 600);            
        }
    }
}