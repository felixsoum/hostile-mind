using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class ClosetRoom3 : Room
    {
        public ClosetRoom3()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-wood");

            builder.AddBlock("block-shelf", currentPlan.Find("s"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("t"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("u"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("o"), 1, "Lots of stuff in here.");

            builder.AddBlock("npc-scott-down", currentPlan.Find("s").Bottom, 1, OnScottChoice, "Attempt to wake up Scott", "Let him sleep...");

            var hallway = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("d0"), hallway.Find("d3").Right);

            builder.FillEdges();
        }
        
        public void OnScottChoice(int x)
        {
            if (x == 1)
            {
                bool isAwakened = false;
                if (PlayerItems.Has(Item.ItemType.SMELLINGSALT))
                {
                    isAwakened = true;
                    Dialog.SetText("You throw some smelling salt at Scott\nScott hands you a key to the storage room");
                }
                else if (PlayerItems.Has(Item.ItemType.BUCKET))
                {
                    isAwakened = true;
                    Dialog.SetText("You splash some water on Scott using your bucket\nScott hands you a key to the storage room");
                }
                else
                {
                    Dialog.SetText("You poke Scott but he shows no reaction");
                }
                
                if (isAwakened)
                {
                    PlayerItems.Add(new Item(Item.ItemType.KEY));
                    Sounds.Get("item").Play();
                }
            }
            else
            {
                Dialog.SetText("Logan: ...I'll deal with him later...");
            }
        }
    }
}

