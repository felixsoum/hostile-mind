using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class Hospital5thFloorUtilityRoom : Room
    {
        RoomBuilder builder;
        
        public Hospital5thFloorUtilityRoom()
        {

            builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 8, 1);

            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            var hallway = RoomPlans.Get(typeof(Hospital5thFloorHallway).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorHallway), currentPlan.Find("d0"), hallway.Find("d5").Top);

            builder.FillEdges();

        }

        public override void Update()
        {
            if (PlayerItems.Has(Item.ItemType.CROWBAR))
            {
                builder.AddBlock("h-wall-hospital-laundrychute", currentPlan.Find("d1"), 1, triggerChute, "Use crowbar and slide down chute", "Leave");
            }
            else
            {
                builder.AddBlock("h-wall-hospital-laundrychute", currentPlan.Find("d1"), 1, "It's crusted over - you can't pry it open");
            }    
                
                base.Update();
        }

        public void triggerChute(int i)
        {
            if (i == 1)
            {
                var basement = RoomPlans.Get(typeof(HospitalBasementLaundryRoom).Name);
                GameInfo.CurrentLevel.RoomTransition.Activate("HospitalBasementLaundryRoom", basement.Find("s2").ToVector());
            }
        }
    }
}
