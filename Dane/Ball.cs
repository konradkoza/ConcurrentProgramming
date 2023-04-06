using System.ComponentModel;

namespace Dane
{
    public class Ball
    {
        
     
         public double x { get; set; }
         public double y { get; set; }
         public double diameter { get; set; } = 20;
         public double xSpeed { get; set; }
         public double ySpeed { get; set; }


         public double X
         {
             get { return x; }

             set
             {
                 x = value;
             }
         }

         public double Y
         {
             get { return y; }
             set
             {
                 y = value;
             }
         }

         public double Diameter
         {
             get
             {
                 return diameter;
             }
             set
             {
                 diameter = value;
             }
         }


         public Ball(double x, double y, double xS, double yS)
         {
             this.x = x;
             this.y = y;
             this.xSpeed = xS;
             this.ySpeed = yS;
         }

    }

}
