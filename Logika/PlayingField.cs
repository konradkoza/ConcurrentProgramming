using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class PlayingField
    {
        private List<Ball> balls = new List<Ball>();
        public int size { get; } = 200;

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

        public List<Ball> getBalls()
        {
            return balls;
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
