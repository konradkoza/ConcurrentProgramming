using Logika;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private float x;
        private float y;
        private int diameter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public float X
        {
            get { return x; }
            set { x = value;
                OnPropertyChanged();
            }
        }

        public float Y
        {
            get { return y; }
            set { y = value;
                OnPropertyChanged();
            }
        }

        public int Diameter
        {
            get { return diameter; }
        }


        public BallModel(float x, float y, int diameter)
        {
            this.x = x;
            this.y = y;
            this.diameter = diameter;
        }

        public void Move(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
