namespace Logika
{
    public class Ball
    {
        public double x { get; set; }
        public double y { get; set; }
        public double diameter { get; set; } = 20;
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

            if (xNew > (size - diameter / 2))
            {
                this.xSpeed = -this.xSpeed;
                xNew -= 2 * xSpeed;
            }
            else if (xNew < (0 + diameter / 2))
            {
                this.xSpeed = -this.xSpeed;
                xNew += 2 * xSpeed;
            }
            else if (yNew > (size - diameter / 2))
            {
                this.ySpeed = -this.ySpeed;
                yNew -= 2 * ySpeed;
            }
            else if (yNew < (0 + diameter / 2))
            {
                this.ySpeed = -this.ySpeed;
                yNew += 2 * ySpeed;
            }

            x = xNew;
            y = yNew;

        }


    }
}