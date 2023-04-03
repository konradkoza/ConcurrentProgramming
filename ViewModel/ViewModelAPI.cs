using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class ViewModelAPI : INotifyPropertyChanged
    {
        public ViewModelAPI() { }

        public string inputNumber = "10";

        public event PropertyChangedEventHandler PropertyChanged;

        public string InputNumber
        {
            get { return inputNumber; }
            set {
                inputNumber = value; 
                OnPropertyChanged(nameof(InputNumber));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}