using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class MasterBedRoom : Room
    {
        private RoomBuilder builder;
        private bool playerCanLeave = false;
        private const int CELL_SOUND_WAIT = 4000;
        private int cellSoundWait = 0;
        private bool isTutorial;
        private Cutscene cellPickupCutscene = new TutorialCutscene2();

        public MasterBedRoom(bool isTutorial = false)
        {
            this.isTutorial = isTutorial;
            builder = new RoomBuilder(this);

            builder.FillFloor("floor-linen");
            if (!isTutorial)
            {
                builder.AddBlock("block-shelf", currentPlan.Find("s"), 2, Item.ItemType.PILL, "You found some PILLS in the shelf.", PlayerActor.Orientation.UP);
            }
            else
            {
                builder.AddBlock("block-shelf", currentPlan.Find("s"), 2, "The shelf.");
                builder.AddItemTile(Item.ItemType.PHONE, currentPlan.Find("p").Top);
                builder.AddPushableBlock("block-shelf", currentPlan.Find("p"));
            }
            builder.AddBlock("block-bed-test", currentPlan.Find("b"), 2, "The bed.");
            builder.AddBlock("block-cabinet", currentPlan.Find("c"), 1, "The cabinet.");
            builder.AddBlock("block-cabinet", currentPlan.Find("c1"), 1, "The cabinet.");

            builder.AddWall("wall-beige", 1, 13, 1);
            builder.AddWall("wall-beige", currentPlan.Find("d0"));

            var hallway2 = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
            if (!isTutorial)
                builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("d0"), hallway2.Find("d1").Left);
            else
            {
                builder.AddDialogToTile("My cell is somewhere in this room...", currentPlan.Find("d0"));
                builder.AddCommandToTile(PlayerActor.Instance, new MoveActorCommand(new Vector2(GameInfo.TILE_X, 0)), currentPlan.Find("d0"));
            }

            if (isTutorial)
                builder.AddLightSource(currentPlan.Find("l1"), 5.5f);
            builder.FillEdges();
        }

        public override void Update()
        {
            base.Update();
            if (!isTutorial)
                return;

            if (!PlayerItems.Has(Item.ItemType.PHONE))
            {
                cellSoundWait -= Time.deltaTime;
                if (cellSoundWait < 0)
                {
                    cellSoundWait = CELL_SOUND_WAIT;
                    Sounds.Get("cell-ring").Play();
                }
            }

            if (!playerCanLeave && PlayerItems.Has(Item.ItemType.PHONE))
            {
                playerCanLeave = true;
                CutsceneServant.Set(GameInfo.CurrentLevel, cellPickupCutscene);
                builder.ClearOnStep(currentPlan.Find("d0"));
                var hallway2 = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
                builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("d0"), hallway2.Find("d1").Left);
            }
        }
    }
}

