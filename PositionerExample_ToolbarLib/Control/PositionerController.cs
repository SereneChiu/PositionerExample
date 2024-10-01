using PositionerExample_ToolbarLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMcraft;

namespace PositionerExample_ToolbarLib.Control
{
    public static class PositionerController
    {
        public static TMcraftToolbarAPI.ToolbarAuxiliaryAxesProvider AxisAdapter { get; set; }
        public static TMcraftToolbarAPI.ToolbarRobotJogProvider JogAdapter { get; set; }

    }
}
