using PositionerExample_ToolbarLib.Control;
using PositionerExample_ToolbarLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace PositionerExample_ToolbarLib.Model
{
    public class PositionerModel : ViewModelBase
    {
        private string _state = EnumExtensions.ToDisplayName(PositionerDefine.State.NORMAL);
        private string _selectedDistance = "";
        private string _selectedSpeed = "";


        private CollectionView _distanceEntries;
        private CollectionView _speedEntries;
        private double _pos_j7 = 0.0;
        private double _pos_j8 = 0.0;

        private double _act_pos_j7 = 0.0;
        private double _act_pos_j8 = 0.0;

        public string BtnLb_Jog_N { get => "Jog (-)"; }
        public string BtnLb_Jog_P { get => "Jog (+)"; }
        public string BtnLb_Jog_Start { get => "Start"; }
        public string BtnLb_Jog_Stop { get => "Stop"; }


        public string Pos_J8
        {
            get => _pos_j7.ToString();
            set => Set(ref _pos_j7, Convert.ToDouble(value), nameof(State));
        }

        public string Pos_J7
        {
            get => _pos_j8.ToString();
            set => Set(ref _pos_j8, Convert.ToDouble(value), nameof(State));
        }


        public string ActPos_J8
        {
            get => _act_pos_j7.ToString();
            set => Set(ref _act_pos_j7, Convert.ToDouble(value), nameof(State));
        }

        public string ActPos_J7
        {
            get => _act_pos_j8.ToString();
            set => Set(ref _act_pos_j8, Convert.ToDouble(value), nameof(State));
        }


        public string State
        {
            get => _state;
            set => Set(ref _state, value, nameof(State));
        }

        public string SelectedDistance
        {
            get => _selectedDistance;
            set => Set(ref _selectedDistance, value, nameof(SelectedDistance));
        }

        public string SelectSpeed
        {
            get => _selectedSpeed;
            set => Set(ref _selectedSpeed, value, nameof(SelectSpeed));
        }

        private IList<ComboboxType> mDisEntries = new List<ComboboxType>()
        {
            new ComboboxType("0.01 mm")
          , new ComboboxType("0.05 mm")
          , new ComboboxType("0.1 mm")
          , new ComboboxType("0.5 mm")
          , new ComboboxType("1 mm")
          , new ComboboxType("5 mm")
          , new ComboboxType("10 mm")
          , new ComboboxType("Continuous")
        };

        private IList<ComboboxType> mSpeedEntries = new List<ComboboxType>()
        {
            new ComboboxType("0.1 %")
          , new ComboboxType("0.5 %")
          , new ComboboxType("1 %")
          , new ComboboxType("5 %")
          , new ComboboxType("10 %")
          , new ComboboxType("15 %")
        };

        public ICommand ButtonClickCommand
        {
            get;
            private set;
        }

        public PositionerModel()
        {
            ButtonClickCommand = new RelayCommand(ClickedMethod);
            _distanceEntries = new CollectionView(mDisEntries);
            _speedEntries = new CollectionView(mSpeedEntries);
            _selectedDistance = mDisEntries[7].TypeName;
            _selectedSpeed = mSpeedEntries[1].TypeName;
        }


        private void ClickedMethod(object obj)
        {
            if (!(obj is string))
            {
                return;
            }
        }


        public CollectionView DistanceEntries
        {
            get { return _distanceEntries; }
        }

        public CollectionView SpeedEntries
        {
            get { return _speedEntries; }
        }

        public SolidColorBrush StateInColor
        {
            get
            {
                if (State == EnumExtensions.ToDisplayName(PositionerDefine.State.WARNING))
                {
                    return new SolidColorBrush(Colors.Yellow);
                }

                if (State == EnumExtensions.ToDisplayName(PositionerDefine.State.ERROR))
                {
                    return new SolidColorBrush(Colors.Red);
                }
                return new SolidColorBrush(Colors.Green);
            }
        }
    }

    public class ComboboxType
    {
        public string TypeName { get; set; }

        public ComboboxType(string Name)
        {
            this.TypeName = Name;
        }
    }
}
