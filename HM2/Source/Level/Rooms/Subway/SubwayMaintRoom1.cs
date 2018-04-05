using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayMaintRoom1 : Room
    {
        RoomBuilder builder;
        SubwayTunnelLG st;

        public SubwayMaintRoom1()
        {
            builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            builder.AddBlock("wall-tunnel-switch", currentPlan.Find("w1"), 3, OnSwitchChoice, "Turn Lights off in the tunnel?", "Turn the Lights on in the tunnel?");
            
           
            var tunnel = RoomPlans.Get(typeof(SubwayTunnelLG).Name);
            builder.AddRoomTransition(typeof(SubwayTunnelLG), currentPlan.Find("d2"), tunnel.Find("d2").Bottom);
            builder.AddRoomTransition(typeof(SubwayTunnelLG), currentPlan.Find("d3"), tunnel.Find("d3").Bottom);

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            builder.AutomaticWall("wall-tunnel");
            //builder.FillEdges();

        }
        public void OnSwitchChoice(int x)
        {
            if (x == 1)
            {
                Dialog.SetText("The lights in the tunnel are now off.");
                st.IsLightingEnabled = true;
            }
            else
            {
                Dialog.SetText("The lights in the tunnel are now back on.");
                st.IsLightingEnabled = false;
            }
        }

        public override void OnRoomCreation(Level level)
        {
            st = level.GetRoom<SubwayTunnelLG>(typeof(SubwayTunnelLG));
        }
    }
}
