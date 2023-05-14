﻿

using Data;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Logika
{
    public abstract class LogicAbstractAPI
    {
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract int GetBallDiameter(int id);
        public abstract float GetBallX(int id);
        public abstract float GetBallY(int id);
        public abstract event EventHandler<(int Id, float X, float Y, int Diameter)>? LogicLayerEvent;

        public abstract void AddBalls(int count);

        public abstract ObservableCollection<IBall> GetBalls();
        public abstract int GetBallsCount();


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
            public override event EventHandler<(int Id, float X, float Y, int Diameter)>? LogicLayerEvent;

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
                    dataAPI.GetBall(i).BallChanged += PositionChanged;

                }

            }

            public override ObservableCollection<IBall> GetBalls()
            {
                return dataAPI.GetBalls();
            }

            public override float GetBallX(int id)
            {
                return dataAPI.GetBall(id).X;
            }

            public override float GetBallY(int id)
            {
                return dataAPI.GetBall(id).Y;
            }

            public override int GetBallDiameter(int id)
            {
                return dataAPI.GetBall(id).Diameter;
            }

            public override void RemoveAllBalls()
            {
                for (int i = 0; i < dataAPI.GetBallCount(); i++)
                {
                    dataAPI.GetBall(i).BallChanged -= PositionChanged;

                }
                dataAPI.RemoveBalls();
            }

            private void PositionChanged(object? sender, EventArgs e)
            {
                if (sender == null)
                {
                    return;
                }
                IBall ball = (IBall)sender;
                DetectBallCollision(ball);
                DetectWallCollision(ball);
                LogicLayerEvent?.Invoke(this, (ball.Id, ball.X, ball.Y, ball.Diameter));
            }


            private void DetectBallCollision(IBall firstBall)
            {


                lock (_collisionLock)
                {
                    for (int i = 0; i < dataAPI.GetBallCount(); i++)
                    {

                        IBall secondBall = dataAPI.GetBall(i);
                        if (firstBall == secondBall)
                        {
                            continue;
                        }
                        
                        if ( IsCollision(firstBall, secondBall))
                        { 

                     
                            Vector2 newFirstBallVel = NewVelocity(firstBall, secondBall);
                            Vector2 newSecondBallVel = NewVelocity(secondBall, firstBall);

                            firstBall.Velocity = newFirstBallVel;
                            secondBall.Velocity = newSecondBallVel;

                        }

                    }
                    
                }
            }

            

            private Vector2 NewVelocity(IBall firstBall, IBall secondBall)
            {
                var ball1Vel = firstBall.Velocity;
                var ball2Vel = secondBall.Velocity;
                var distance = firstBall.Position - secondBall.Position;
                return firstBall.Velocity -
                       2.0f * secondBall.Mass / (firstBall.Mass + secondBall.Mass)
                       * (Vector2.Dot(ball1Vel - ball2Vel, distance) * distance) /
                       (float)Math.Pow(distance.Length(), 2);
            }

            private bool IsCollision(IBall firstBall, IBall secondBall)
            {
                if (firstBall == null || secondBall == null)
                {
                    return false;
                }
                float distance = Vector2.Distance(firstBall.Position, secondBall.Position);
                return distance <= (firstBall.Diameter + secondBall.Diameter) / 2;
            }

            private void DetectWallCollision(IBall ball)
            {

                Vector2 newVel = new Vector2(ball.Velocity.X, ball.Velocity.Y);
                int Radius = ball.Diameter / 2;
                if (ball.Position.X - Radius <= -1)
                {
                    newVel.X = Math.Abs(ball.Velocity.X);

                }
                else if (ball.Position.X + Radius >= Width)
                {
                    newVel.X = -Math.Abs(ball.Velocity.X);

                }
                if (ball.Position.Y - Radius <= -1)
                {
                    newVel.Y = Math.Abs(ball.Velocity.Y);
                }
                else if (ball.Position.Y + Radius >= Height)
                {
                    newVel.Y = -Math.Abs(ball.Velocity.Y);

                }

                ball.Velocity = newVel;
            }

            public override int GetBallsCount()
            {
                return dataAPI.GetBallCount();
            }

        }

    }

}