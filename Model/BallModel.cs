using Logika;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private float _left;
        private float _top;
        private int diameter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public float Left
        {
            get { return _left; }
            set {
                _left = value;
                OnPropertyChanged();
            }
        }

        public float Top
        {
            get { return _top; }
            set {
                _top = value;
                OnPropertyChanged();
            }
        }

        public int Diameter
        {
            get { return diameter; }
        }


        public BallModel(float x, float y, int diameter)
        {
            Top = y - diameter / 2;
            Left = x - diameter / 2;

            this.diameter = diameter;
        }

        public void Move(float x, float y)
        {
            this.Left = x;
            this.Top = y;
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
