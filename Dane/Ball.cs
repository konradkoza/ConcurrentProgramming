using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data
{
    [Serializable]
    internal class Ball : IBall
        {
            private Task task;

            private bool _move = true;

            private int _diameter;

            private Stopwatch _stopwatch;

            private DAO _dao;

            private int _mass;

            public Ball(float x, float y, int mass, Vector2 velocity, int diameter, int id, DAO dao)
            {
                _stopwatch = new Stopwatch();
                Id = id;
                _position = new Vector2(x, y);
                _velocity = velocity;
                _diameter = diameter;
                _mass = mass;
                task = Task.Run(Move);
                _dao = dao;
            }

            public event EventHandler? BallChanged;

            private Vector2 _position;

        [JsonConverter(typeof(Vector2Converter))]
        public Vector2 Position
            {
                get => _position;

                private set
                {
                    _position = value;
                }
            }

            private Vector2 _velocity;
        [JsonConverter(typeof(Vector2Converter))]
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

            public int Mass { get => _mass;
                private set { _mass = value; }
                }


            public int Id { get; }

            private async void Move()
            {
                int delay = 15;

                while (_move)
                {
                    _stopwatch.Restart();
                    _stopwatch.Start();
                    delay = (int)(5 * _velocity.Length());
                    Update(delay);
                                       
                    _stopwatch.Stop();
                    await Task.Delay(delay - (int)_stopwatch.ElapsedMilliseconds < 0 ? 0 : delay - (int)_stopwatch.ElapsedMilliseconds);
                }

            }

            private void Update(long time)
            {
                Position += _velocity * time;              
                BallChanged?.Invoke(this, EventArgs.Empty);
                _dao.addToQueue((Ball)this.MemberwiseClone());
            }

            public void Dispose()
            {
                _move = false;
                task.Wait();
                task.Dispose();     
            }

       
    }
    internal class Vector2Converter : JsonConverter<Vector2>
    {
        public override Vector2 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Vector2 value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("X", value.X);
            writer.WriteNumber("Y", value.Y);
            writer.WriteEndObject();
        }
    }
}
