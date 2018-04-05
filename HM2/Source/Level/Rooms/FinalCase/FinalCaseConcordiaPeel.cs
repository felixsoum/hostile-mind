using System;

namespace HostileMind
{
    public class FinalCaseConcordiaPeel : Room
    {
        private const string ROCK_TEXT = "There are so many pieces of rock!";
        private bool trade = false;

        public FinalCaseConcordiaPeel()
        {
            var builder = new RoomBuilder(this);

            //FLOOR

            //concrete
            builder.FillFloor("floor-concrete-old", currentPlan.Find("c0"), 134, 1); //178
            builder.FillFloor("floor-concrete-old", currentPlan.Find("c1"), 134, 1);
            builder.FillFloor("floor-concrete-old", currentPlan.Find("t0"), 1, 1); //behind door
            //tracks
            builder.FillFloor("floor-htracks", currentPlan.Find("f0"), 134, 5); //178
            builder.FillFloor("floor-htracks", currentPlan.Find("f1"), 134, 5);


            //WALLS

            builder.AddWall("wall-tunnel", 1, 116, 2);
            builder.AddWall("wall-tunnel", 118, 134, 2);
            //lights
            for (int i = 0; i < 7; i++) //9 (max)
                builder.AddWall("wall-tunnel2", 1 + 22 * i, 1 + 22 * i + 1, 2);
            //signs
            for (int i = 0; i < 6; i++) //8 (max-1)
                builder.AddWall("wall-tunnel3", 1 + 11 + 22 * i, 1 + 11 + 22 * i + 1, 2);

            //BLOCKS
            foreach (var p in currentPlan.FindAll("p"))
                builder.AddPushableBlock("stone-brown", p);
            foreach (var r in currentPlan.FindAll("r"))
                builder.AddBlock("block-debris", r, 1, ROCK_TEXT);

            //ITEMS

            //none


            //EVENTS

            //stm guy's voice
            builder.AddSingleDialogToTile("Voice: \"Ah, I'm so thirsty...\"", 
                currentPlan.Find("e0"));

            //stm guy interaction (placeholder)
            builder.AddBlock("npc-stm", currentPlan.Find("stm"), 1, OnStmChoice, "Give water bottle", "Ignore");
            
            //door
            builder.AddItemLockedDoor(currentPlan.Find("t0"), DoorSprite.Orientation.DOWN, Item.ItemType.KEYCARD,
                "The door is locked. \nOnly STM staff are authorized.", "door-tunnel");
            //thoughts
            foreach (var e1 in currentPlan.FindAll("e1"))
                builder.AddDialogToTile("I hope Sandra is okay...", e1);
            foreach (var e2 in currentPlan.FindAll("e2"))
                builder.AddDialogToTile("What a long tunnel.", e2);
            //signs
            for (int i = 0; i < 6; i++) //8 (max-1)
            {
                builder.AddDialogToTile(
                    "Right: Peel\nLeft: Guy-Concordia", 1 + 11 + 22 * i, 2);
                builder.AddDialogToTile(
                    "Right: Peel\nLeft: Guy-Concordia", 1 + 11 + 22 * i + 1, 2);
            }


            //TRANSITIONS

            //back to concordia-2
            var c2 = RoomPlans.Get(typeof(FinalCaseConcordia2).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d0"), c2.Find("d16").Bottom);

            //to tunnel room
            var room = RoomPlans.Get(typeof(FinalCaseTunnelRoom).Name);
            builder.AddRoomTransition(typeof(FinalCaseTunnelRoom), currentPlan.Find("t0"), room.Find("d0").Top);

            //to peel
            var peel = RoomPlans.Get(typeof(FinalCasePeel).Name);
            builder.AddRoomTransition(typeof(FinalCasePeel), currentPlan.Find("d1"), peel.Find("d0").Right);

            foreach (var c in currentPlan.FindAll("#"))
              builder.ClearFloor(c);

        }//end of constructor

        public void OnStmChoice(int x)
        {
            string text;
            //if (!trade)
            //{
                switch (x)
                {
                    case 1:
                        if (PlayerItems.Has(Item.ItemType.BOTTLE))
                        {
                            text = "STM Staff: \"Thank you so much, I feel refreshed!\" \nYou acquired the KEYCARD item.";
                            PlayerItems.Remove(Item.ItemType.BOTTLE);
                            PlayerItems.Add(new Item(Item.ItemType.KEYCARD));
                            Sounds.Get("item").Play();
                            trade = true;
                        }
                        else
                            text = "STM Staff: \"Huh? You don't have a water bottle.\"";
                        //livingRoom.SampleMessage();
                        break;
                    default:
                        text = "I don't have time for this.";
                        break;
                }
            //}
            //else
            //{
            //    text = "STM Staff: \"Be careful, there is a fire ahead.\"";
            //}
            Dialog.SetText(text);
        }
    }
}
