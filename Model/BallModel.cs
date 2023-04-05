using Logika;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private Ball ball;


        public BallModel(Ball ball)
        {
            this.ball = ball;
        }


        public double X
        {
            get { return ball.x; }

            set
            {
                ball.x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return ball.y; }
            set
            {
                ball.y = value;
                OnPropertyChanged("Y");
            }
        }

        public double Diameter
        {
            get
            {
                return ball.diameter;
            }
            set
            {
                ball.diameter = value;
                OnPropertyChanged("Diameter");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
