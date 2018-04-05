using System;

namespace HostileMind
{
    public class FinalCaseTunnelRoom : Room
    {
        public FinalCaseTunnelRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");
            builder.AddWall("wall-tunnel", 1, 11, 2);

            //light
            builder.AddLightSource(currentPlan.Find("l0"), 4.5f);

            //ITEMS

            builder.AddItemTile(Item.ItemType.EXTINGUISHER, currentPlan.Find("i0"));

            //back to concordia-peel tunnel
            var cp = RoomPlans.Get(typeof(FinalCaseConcordiaPeel).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordiaPeel), currentPlan.Find("d0"), cp.Find("t0").Bottom);

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);
        }
    }
}
