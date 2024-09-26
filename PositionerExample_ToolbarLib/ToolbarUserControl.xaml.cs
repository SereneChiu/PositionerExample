using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMcraft;

namespace PositionerExample_ToolbarLib
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ToolbarUserControl : UserControl, ITMcraftToolbarEntry
    {
        private TMcraftToolbarAPI mTMcraftToolbarAPI = null;

        public ToolbarUserControl()
        {
            InitializeComponent();
        }

        public void InitializeToolbar(TMcraftToolbarAPI Api)
        {
            mTMcraftToolbarAPI = Api;
            //_axis_adapter = mTMcraftToolbarAPI.AuxiliaryAxesProvider;
        }

    }

}
