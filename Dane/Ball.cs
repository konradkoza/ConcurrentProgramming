using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Ball : IBall
    {
        private Task task;

        private bool move = true;


        public Ball(float x, float y, int mass, Vector2 velocity, int id)
        {
            Id = id;
            _position = new Vector2(x, y);
            _velocity = velocity;
            Mass = mass;
            task = Task.Run(Move);
        }

        public event EventHandler<BallChangedEventArgs>? BallChanged;

        private Vector2 _position;

        public Vector2 Position => _position;

        private Vector2 _velocity;

        public Vector2 Velocity
        {
            get => _velocity;
            set {
                
                _velocity = value; 
                
            }
        }

        public float X => _position.X;

        public float Y => _position.Y;

        public int Mass { get; }


        public int Id { get; }

        private async void Move()
        {
            while (move)
            {
                _position += _velocity;

                BallChanged?.Invoke(this, new BallChangedEventArgs(this));

                await Task.Delay((int)Vector2.Divide(_velocity, 10).Length());
            }

        }

        public void StopMovement()
        {
            move = false;
        }

        public void Dispose()
        {
            task.Dispose();
        }
    }
}
