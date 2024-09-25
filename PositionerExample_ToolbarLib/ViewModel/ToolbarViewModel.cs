using PositionerExample_ToolbarLib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PositionerExample_ToolbarLib.ViewModel
{
    public class ToolbarViewModel : ViewModelBase
    {
        public UserControl MyUserControlVM { get; set; } = new ToolbarTabControl();
    }
}
