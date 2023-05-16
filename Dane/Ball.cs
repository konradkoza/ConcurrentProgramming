using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   
    internal class Ball : IBall
        {
            private Task task;

            private bool _move = true;

            private int _diameter;

            public Ball(float x, float y, int mass, Vector2 velocity, int diameter, int id)
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
}
