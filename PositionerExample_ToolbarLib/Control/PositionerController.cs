using PositionerExample_ToolbarLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMcraft;
using static TMcraft.TMcraftToolbarAPI;

namespace PositionerExample_ToolbarLib.Control
{
    public class PositionerController
    {
        private PositionerModel _positionerModel = new PositionerModel();
        private ToolbarAuxiliaryAxesProvider _axis_adapter = null;


        public PositionerController(ToolbarAuxiliaryAxesProvider Adapter)
        {
            Adapter = _axis_adapter;
        }

        public void Jog()
        {
            _axis_adapter?.JogAngle(_positionerModel.Pos_J7, _positionerModel.Pos_J8, _positionerModel.d)
        }

    }
}
