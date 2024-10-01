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

        private bool _check_j7;
        private bool _check_j8;
        private bool _enable_sync = false;

        public event EventHandler OnExternalLibraryInteractionRequested;

        public string BtnLb_Jog_N { get => "Jog (-)"; }
        public string BtnLb_Jog_P { get => "Jog (+)"; }
        public string BtnLb_Jog_Start { get => "Start"; }
        public string BtnLb_Jog_Stop { get => "Stop"; }

        public bool Enable_Sync
        {
            get => _enable_sync;
            set => Set(ref _enable_sync, value, nameof(Enable_Sync));
        }

        public bool Enable_Single { get { return !Enable_Sync; } }

        public bool Check_J7
        {
            get => _check_j7;
            set => Set(ref _check_j7, value, nameof(Check_J7));
        }

        public bool Check_J8
        {
            get => _check_j8;
            set => Set(ref _check_j8, value, nameof(Check_J8));
        }

        public string Pos_J7
        {
            get => _pos_j7.ToString();
            set => Set(ref _pos_j7, Convert.ToDouble(value), nameof(Pos_J7));
        }

        public string Pos_J8
        {
            get => _pos_j8.ToString();
            set => Set(ref _pos_j8, Convert.ToDouble(value), nameof(Pos_J8));
        }


        public double Pos_J7_Double
        {
            get => _pos_j7;
            set => Set(ref _pos_j7, value, nameof(Pos_J7));
        }

        public double Pos_J8_Double
        {
            get => _pos_j8;
            set => Set(ref _pos_j8, value, nameof(Pos_J8));
        }


        public string ActPos_J7
        {
            get => _act_pos_j7.ToString();
            set => Set(ref _act_pos_j7, Convert.ToDouble(value), nameof(ActPos_J7));
        }

        public string ActPos_J8
        {
            get => _act_pos_j8.ToString();
            set => Set(ref _act_pos_j8, Convert.ToDouble(value), nameof(ActPos_J8));
        }


        public double ActPos_J7_Double
        {
            get => _act_pos_j7;
            set => Set(ref _act_pos_j7, value, nameof(ActPos_J7));
        }

        public double ActPos_J8_Double
        {
            get => _act_pos_j8;
            set => Set(ref _act_pos_j8, value, nameof(ActPos_J8));
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

        public string SelectedSpeed
        {
            get => _selectedSpeed;
            set => Set(ref _selectedSpeed, value, nameof(SelectedSpeed));
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
            _selectedDistance = mDisEntries[6].TypeName;
            _selectedSpeed = mSpeedEntries[1].TypeName;
        }


        private void ClickedMethod(object obj)
        {
            if (!(obj is string))
            {
                return;
            }

            OnExternalLibraryInteractionRequested?.Invoke(obj, EventArgs.Empty);

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
