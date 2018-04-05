using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class LivingRoom : Room
    {
        private RoomBuilder builder;
        private Cutscene chaseCutscene = new HouseChaseCutscene();
        private Cutscene aidCutscene = new HouseAidCutscene();
        private HouseHallwayTwoRoom hallwayTwo;
        
        public LivingRoom(Actor shadow)
        {
            builder = new RoomBuilder(this);

            builder.FillFloor("floor-linen");

            builder.AddBlock("block-sofa", currentPlan.Find("s"), 2);
            builder.AddBlock("block-fireplace", currentPlan.Find("f"), 1);
            builder.AddBlock("block-cabinet", currentPlan.Find("c"), 1, "This is a cabinet.");
            builder.AddBlock("block-table2", currentPlan.Find("t"), 2, "This is a table.");

            builder.AddBlock("npc-house-wife", currentPlan.Find("b"), 1, OnWifeChoice, "Use items on Karen", "Look for more items");

            builder.AddWall("wall-beige", 1, 8, 1);
            builder.AddWall("wall-beige", 11, 18, 1);

            builder.AddChoice(OnPathChoice, "Chase the shadow", "Check on Karen", currentPlan.Find("e"));
            
            var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);

            // Top
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), hallway.Find("d4").Top);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d1"), hallway.Find("d5").Top);

            // Left
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d2"), hallway.Find("d6").Left);
            builder.AddWall("wall-beige", currentPlan.Find("d2"));
            builder.FillEdges();
            
            shadow.Position = currentPlan.Find("b").Right.Right.ToVector();
            AddNpc(shadow);
        }
        
        public override void OnRoomCreation(Level level)
        {
            hallwayTwo = level.GetRoom<HouseHallwayTwoRoom>(typeof(HouseHallwayTwoRoom));
        }
        
        public void OnPathChoice(int x)
        {
            if (x == 1)
            {
                builder.AddBlock("npc-house-wife", currentPlan.Find("b"), 1, "Karen is dead...");
                Dialog.SetText("Logan: I cannot let this bastard get away...\nRevenge!");
                CutsceneServant.Set(GameInfo.CurrentLevel, chaseCutscene);
            }
            else
            {
                hallwayTwo.FixShelf();
                Dialog.SetText("Logan: Oh god Karen please...");
                CutsceneServant.Set(GameInfo.CurrentLevel, aidCutscene);
            }
        }

        public void OnWifeChoice(int x)
        {
            if (x == 1)
            {
                int itemsMissing = 4;

                if (PlayerItems.Has(Item.ItemType.MEDKIT))
                    itemsMissing--;

                if (PlayerItems.Has(Item.ItemType.TOWEL))
                    itemsMissing--;

                if (PlayerItems.Has(Item.ItemType.BANDAGE))
                    itemsMissing--;

                if (PlayerItems.Has(Item.ItemType.PILL))
                    itemsMissing--;

                if (itemsMissing == 0)
                {
                    GameDirector.TransitionTo(new HospitalCinematic());
                }
                else
                {
                    PlayerActor.Instance.LifeCount--;
                    Dialog.SetText("Logan: Argh... This is not working.\nI'm still missing " + itemsMissing + " items...");
                    
                    if (PlayerActor.Instance.LifeCount == 0)
                    {
                        GameDirector.TransitionTo(new GameOverL1WifePath());
                    }
                }
            }
            else
            {
                Dialog.SetText("Logan: I need to hurry up...");
            }
        }

        public void SampleMessage()
        {
            // Do nothing
        }
    }
}

