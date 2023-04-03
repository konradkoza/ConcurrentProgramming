using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Logika
{
    public class Ball
    {
        public double x { get; set; }
        public double y { get; set; }
        private double diameter { get; set; } = 20;
        private double xSpeed { get; set; }
        private double ySpeed { get; set; }

        public Ball(double x, double y)
        {   
            this.x = x;
            this.y = y;
            this.xSpeed = 0.2;
            this.ySpeed = 0.3;
        }


        public void move(int size)
        {
            double xNew = this.x + xSpeed;
            double yNew = this.y + ySpeed;

            if(xNew > (size - diameter / 2)) {
                this.xSpeed = -this.xSpeed;
            }
            if(yNew > (size - diameter / 2))
            {
                this.ySpeed= -this.ySpeed;
            }

            x = xNew;
            y = yNew;

        }

      
    }
}