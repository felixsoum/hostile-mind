using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class KitchenRoom : Room
    {
        private LivingRoom livingRoom;

        public KitchenRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-marble");

            builder.AddBlock("block-sink", currentPlan.Find("s"), 1, "I don't have time to wash the blood off of my hands.\nI need to hurry.");
            builder.AddBlock("block-fridge", currentPlan.Find("f"), 1, OnFridgeChoice, "Drink milk", "Close fridge");
            builder.AddBlock("block-table", currentPlan.Find("t"), 5, "The table is clean.");

            

            builder.AddWall("wall-beige", 1, 8, 1);

            var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), hallway.Find("d2").Bottom);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d1"), hallway.Find("d3").Bottom);
            builder.FillEdges();
        }

        public override void OnRoomCreation(Level level)
        {
            livingRoom = level.GetRoom<LivingRoom>(typeof(LivingRoom));
        }

        public void OnFridgeChoice(int x)
        {
            string text;
            switch (x)
            {
                case 1:
                    text = "I feel more relaxed.";
                    livingRoom.SampleMessage();
                    break;
                default:
                    text = "This is not the time to be exploring the fridge.";
                    break;
            }
            Dialog.SetText(text);
        }
    }
}

