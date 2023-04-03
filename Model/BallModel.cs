using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class BallModel
    {
        private Ball ball;


        public BallModel(Ball ball)
        {
            this.ball = ball;
        }


        public double X
        {
            get { return ball.x; }
        }

        public double Y
        {
            get { return ball.y; }
        }

    }
}
