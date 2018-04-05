using System;

namespace HostileMind
{
    public class MidLevelHospitalRoom : Room
    {
        public MidLevelHospitalRoom()
        {
//            AddNpc(actor);
            Textures.Load("logan-bedRidden");
            var builder = new RoomBuilder(this);
            builder.FillFloor("floor-marble");
            builder.AddBlock("logan-bedRidden", currentPlan.Find("b"), 1);
            builder.AddWall("wall-beige", 1, 13, 1);
            builder.FillEdges();
        }
    }
}

