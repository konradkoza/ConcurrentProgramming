using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class PlayingField
    {
        public List<Ball> balls { get; } = new List<Ball>();
        public int size { get; } = 500;

        public int interval { get; } = 20;



        public PlayingField(int height)
        {

            this.size = height;

        }

        public PlayingField() { }

        public void addBall(Ball b)
        {
            this.balls.Add(b);
        }

        public void moveBalls()
        {
            foreach (Ball b in this.balls)
            {
                b.move(size);
            }
        }


    }
}
