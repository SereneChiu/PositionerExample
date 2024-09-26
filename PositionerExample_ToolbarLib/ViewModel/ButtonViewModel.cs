using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PositionerExample_ToolbarLib.ViewModel
{
    public class ButtonViewModel : ViewModelBase
    {
        private string _buttonLabel;

        public string ButtonLabel
        {
            get => _buttonLabel;
            set => Set(ref _buttonLabel, value, nameof(ButtonLabel));
        }

        public ICommand ButtonClickCommand { get; }

        public ButtonViewModel()
        {
            ButtonLabel = "Click Me";

            ButtonClickCommand = new RelayCommand(ExecuteButtonClick, CanExecuteButtonClick);
        }

        private void ExecuteButtonClick(object parameter)
        {
            ButtonLabel = "Clicked!";
        }

        private bool CanExecuteButtonClick(object parameter)
        {
            return true;
        }
    }
}
