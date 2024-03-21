using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class StatWindow : UIWindow
    {
        private Entity entity;

        public StatWindow(Player player) : base(GlobalVariables.statWindowWidth, GlobalVariables.statWindowHeight)
        {
            this.entity = player;
        }

        public void SetPlayerInfo()
        {
            base.AddLine(1, "NAME: " + entity.GetName());
            base.AddLine(2, "HP: " + entity.health.GetHp() + "/" + entity.health.GetMaxHp());
            base.AddLine(3, "ATK: " + entity.atk.GetStat());
            base.AddLine(4, "DEF: " + entity.def.GetStat());
            base.AddLine(5, "MAG: " + entity.mag.GetStat());
            base.AddLine(6, "RES: " + entity.res.GetStat());
            base.AddLine(7, "SPD: " + entity.spd.GetStat());
            base.AddLine(8, "SKL: " + entity.skl.GetStat());
            base.AddLine(9, "LUC: " + entity.luc.GetStat());
        }

        public void ChangeTarget(Entity entity)
        {
            this.entity = entity;
        }
    }
}
