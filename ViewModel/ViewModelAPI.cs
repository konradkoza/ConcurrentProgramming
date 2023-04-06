using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelAPI : INotifyPropertyChanged
    {

        public string inputNumber = "10";

        public ICommand OnClickStartButton { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<BallModel> ballList { get; set; } = new ObservableCollection<BallModel>();

        private ModelAbstractAPI modelAPI;

        public ViewModelAPI()
        {
            OnClickStartButton = new CustomCommand(() => StartButtonHandle());
            modelAPI = ModelAbstractAPI.CreateApi();
        }

        public void StartButtonHandle()
        {
            
            modelAPI.addBalls(getInputValue());
            modelAPI.addModelBalls();
            foreach (BallModel ball in modelAPI.BallModels)
            {
                ballList.Add(ball);
                
            }
            OnPropertyChanged(nameof(ballList));
            modelAPI.Start(); 
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