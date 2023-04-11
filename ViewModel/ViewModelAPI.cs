using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace ViewModel
{
    public class ViewModelAPI : INotifyPropertyChanged
    {

        public bool IsEnabled { get; set; } = true;

        public string inputNumber = "10";

        public ICommand OnClickStartButton { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<BallModel> ballList { get; set; } = new ObservableCollection<BallModel>();

        private ModelAbstractAPI modelAPI;

        public ViewModelAPI()
        {
            OnClickStartButton = new RelayCommand(() => StartButtonHandle());
            modelAPI = ModelAbstractAPI.CreateApi();
        }

        public void StartButtonHandle()
        {
            int value = getInputValue();
            if (value > 0)
            {
                IsEnabled = false;
                OnPropertyChanged(nameof(IsEnabled));
                modelAPI.AddBalls(value);
                modelAPI.AddModelBalls();
                foreach (BallModel ball in modelAPI.BallModels)
                {
                    ballList.Add(ball);

                }
                OnPropertyChanged(nameof(ballList));
                modelAPI.Start();
            }

        }

        public string InputNumber
        {
            get { return inputNumber; }
            set
            {
                inputNumber = value;
                OnPropertyChanged(nameof(InputNumber));
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