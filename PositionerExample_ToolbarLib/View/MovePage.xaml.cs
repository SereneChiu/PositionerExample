using PositionerExample_ToolbarLib.Control;
using PositionerExample_ToolbarLib.Model;
using PositionerExample_ToolbarLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PositionerExample_ToolbarLib.View
{
    /// <summary>
    /// Interaction logic for MovePage.xaml
    /// </summary>
    public partial class MovePage : UserControl
    {
        public PositionerModel _viewModel = new PositionerModel();
        private static DispatcherTimer readDataTimer = new DispatcherTimer();

        public MovePage()
        {
            InitializeComponent();
            DataContext = _viewModel;

            _viewModel.OnExternalLibraryInteractionRequested += ViewModel_OnExternalLibraryInteractionRequested;

            readDataTimer.Tick += new EventHandler(UpdateAxisState);
            readDataTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            readDataTimer.Start();
        }


        private void UpdateAxisState(object? sender, EventArgs e)
        {
            if (PositionerController.AxisAdapter == null) { return; }
            if (PositionerController.AxisAdapter?.GetAngle() == null) { return; }
            if (PositionerController.AxisAdapter?.GetAngle().Length != 2) { return; }

            float[] act_poc = new float[2];
            _viewModel.ActPos_J7_Double = act_poc[0];
            _viewModel.ActPos_J8_Double = act_poc[1];
        }

        private void ViewModel_OnExternalLibraryInteractionRequested(object? sender, EventArgs e)
        {
            if (!(sender is string))
            {
                return;
            }

            string btn_name = sender as string;

            int speed = (int)(Convert.ToDouble(_viewModel.SelectedSpeed.Replace(" %", "")) * 100);
            float[] angle_arr = new float[2] {0, 0};
            angle_arr[0] = (float)_viewModel.ActPos_J7_Double;
            angle_arr[1] = (float)_viewModel.ActPos_J8_Double;

            float dis = float.Parse(_viewModel.SelectedDistance.Replace(" mm", ""), CultureInfo.InvariantCulture.NumberFormat);

            switch (btn_name)
            {
                case "Jog (-)":
                    
                    if (_viewModel.Check_J7) { angle_arr[0] -= dis; }
                    if (_viewModel.Check_J8) { angle_arr[1] -= dis; }
                    PositionerController.AxisAdapter?.JogAngle(angle_arr, speed, 50, _viewModel.Enable_Sync);
                    break;

                case "Jog (+)":
                    if (_viewModel.Check_J7) { angle_arr[0] += dis; }
                    if (_viewModel.Check_J8) { angle_arr[1] += dis; }
                    PositionerController.AxisAdapter?.JogAngle(angle_arr, speed, 50, _viewModel.Enable_Sync);
                    break;

                case "Start":

                    if (_viewModel.Check_J7) 
                    { 
                        angle_arr[0] = float.Parse(_viewModel.Pos_J7, CultureInfo.InvariantCulture.NumberFormat);

                    }
                    if (_viewModel.Check_J8) 
                    { 
                        angle_arr[1] = float.Parse(_viewModel.Pos_J8, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    PositionerController.AxisAdapter?.JogAngle(angle_arr, speed, 50, _viewModel.Enable_Sync);
                    break;

                case "Stop":

                    PositionerController.JogAdapter?.StopJog();

                    break;
            }

        }
    }
}
