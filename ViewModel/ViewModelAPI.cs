using Data;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace ViewModel
{
    public class ViewModelAPI : INotifyPropertyChanged
    {
        public int Width { get; } = 500;
        public int Height { get; } = 500;
        public bool isStartEnabled { get; set; } = true;

        public bool isStopEnabled { get; set; } = false;

        public string inputNumber = "3";

        public ICommand OnClickStartButton { get; set; }

        public ICommand OnClickStopButton { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<BallModel> Balls { get; }

        private ModelAbstractAPI modelAPI;

        public bool IsStartEnabled
        {
            get { return isStartEnabled; }
            set
            {
                isStartEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsStopEnabled
        {
            get { return isStopEnabled; }
            set
            {
                isStopEnabled = value;
                OnPropertyChanged();
            }
        }

        public ViewModelAPI()
        {
            OnClickStartButton = new RelayCommand(() => StartButtonHandle());
            OnClickStopButton = new RelayCommand(() => StopButtonHandle());
            modelAPI = ModelAbstractAPI.CreateApi(Width, Height);
            Balls = modelAPI.Balls;
        }

        public void StopButtonHandle()
        {
            modelAPI.Stop();
            Balls.Clear();
            this.IsStartEnabled = true;
            this.IsStopEnabled = false;

        }

        public void StartButtonHandle()
        {
            int value = getInputValue();
            if (value > 0)
            {
                this.IsStartEnabled = false;
                this.IsStopEnabled = true;
                modelAPI.AddBalls(value);
            }

        }

        public string InputNumber
        {
            get { return inputNumber; }
            set
            {
                inputNumber = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int getInputValue()
        {
            if (Int32.TryParse(InputNumber, out int value) && InputNumber != "0")
            {
                return Int32.Parse(InputNumber);
            }

            return 0;
        }
    }
}