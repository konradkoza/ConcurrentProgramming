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

        public Ball(float x, float y, int mass, Vector2 velocity ) {
            _position = new Vector2(x, y);
            _velocity = velocity;
            Mass = mass;
        
        }

        public event EventHandler<BallChangedEventArgs>? BallChanged;

        private Vector2 _position;

        public Vector2 Position => _position;

        private Vector2 _velocity;

        public Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        public float X => _position.X;

        public float Y => _position.Y;

        public int Mass { get; }


        public int Id { get; }

        
    }
}
