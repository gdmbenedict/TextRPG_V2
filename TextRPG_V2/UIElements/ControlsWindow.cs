using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class ControlsWindow : UIWindow
    {

        public ControlsWindow() : base(GlobalVariables.controlsWindowWidth, GlobalVariables.controlsWindowWidth)
        {
            base.AddLine(1, "UP: W/UP ARROW");
            base.AddLine(2, "RIGHT: D/RIGHT ARROW");
            base.AddLine(3, "DOWN: S/DOWN ARROW");
            base.AddLine(4, "LEFT: A/LEFT ARROW");
            base.AddLine(5, "SWITH STANCE: E");
            base.AddLine(6, "EXIT: ESC");
            base.AddLine(8, "====================");
            base.AddLine(10, "Player = @");
            base.AddLine(11, "Goal = >");
        }
    }
}
