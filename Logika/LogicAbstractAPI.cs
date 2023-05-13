

using Data;
using System.Numerics;

namespace Logika
{
    public abstract class LogicAbstractAPI
    {
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }

        public const int Diameter = 20;

        public abstract void AddBalls(int count);

        public abstract IEnumerable<IBall> GetBalls();

        public abstract void RemoveAllBalls();
        public static LogicAbstractAPI CreateAPI(int width, int height)
        {
            return new LogicAPI(width, height);
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
                for (int i = 0; i < count; i++)
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
                if (sender == null)
                {
                    return;
                }
                IBall firstBall = (IBall)sender;

                lock (_collisionLock)
                {
                    for (int i = 0; i < dataAPI.GetBallCount(); i++)
                    {
                        IBall secondBall = dataAPI.GetBall(i);
                        if(IsCollision(firstBall, secondBall))
                        {
                            Vector2 normal = Vector2.Normalize(secondBall.Position - firstBall.Position);
                            Vector2 tangent = new Vector2(-normal.Y, normal.X);


                            float ball1InitialNormalVelocity = Vector2.Dot(normal, firstBall.Velocity);
                            float ball1InitialTangentVelocity = Vector2.Dot(tangent, firstBall.Velocity);
                            float ball2InitialNormalVelocity = Vector2.Dot(normal, secondBall.Velocity);
                            float ball2InitialTangentVelocity = Vector2.Dot(tangent, secondBall.Velocity);


                            float ball1FinalNormalVelocity = (ball1InitialNormalVelocity * (firstBall.Mass - secondBall.Mass) +
                                2 * secondBall.Mass * ball2InitialNormalVelocity) / (firstBall.Mass + secondBall.Mass);
                            float ball2FinalNormalVelocity = (ball2InitialNormalVelocity * (secondBall.Mass - firstBall.Mass) +
                                2 * firstBall.Mass * ball1InitialNormalVelocity) / (firstBall.Mass + secondBall.Mass);

                            Vector2 ball1FinalVelocity = ball1FinalNormalVelocity * normal + ball1InitialTangentVelocity * tangent;
                            Vector2 ball2FinalVelocity = ball2FinalNormalVelocity * normal + ball2InitialTangentVelocity * tangent;

                            firstBall.Velocity = ball1FinalVelocity;
                            secondBall.Velocity = ball2FinalVelocity;
                        }
                    }
                }
            }

            private bool IsCollision(IBall firstBall, IBall secondBall)
            {
                if(firstBall == null || secondBall == null)
                {
                    return false;
                }
                float distance = Vector2.Distance(firstBall.Position, secondBall.Position);
                return distance <= (Diameter + Diameter) / 2;
            }

            private void DetectWallCollision(object? sender, EventArgs args)
            {
                if (sender == null)
                {
                    return;
                }
                IBall ball = (IBall)sender;
                Vector2 newVel = new Vector2(ball.Velocity.X, ball.Velocity.Y);
                int Radius = Diameter / 2;
                if (ball.Position.X - Radius <= 0)
                {
                    newVel.X = -ball.Velocity.X;

                }
                else if (ball.Position.X + Radius >= Width)
                {
                    newVel.X = -ball.Velocity.X;

                }
                if (ball.Position.Y - Radius <= 0)
                {
                    newVel.Y = -ball.Velocity.Y;
                }
                else if (ball.Position.Y + Radius >= Height)
                {
                    newVel.Y = -ball.Velocity.Y;

                }

                ball.Velocity = newVel;
            }

        }

    }
    
}