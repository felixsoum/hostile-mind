using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class LockedRoom : Room
    {
        private bool isCutsceneTriggered = false;
		private Cutscene escapeCutscene;
        
        public LockedRoom()
        {
            var builder = new RoomBuilder(this);

            var shadow = new ShadowActor();
			shadow.Position = currentPlan.Find("w").Right.Right.Right.Right.Right.ToVector();;
			shadow.Orient(Actor.Orientation.RIGHT);
			AddNpc(shadow);

			escapeCutscene = new HouseEscapeCutscene(shadow);
            builder.FillFloor("floor-linen");

            builder.AddBlock("block-table2", currentPlan.Find("t"), 2, "This is a table.");
            
            builder.AddBlock("block-tv", currentPlan.Find("v"), 2, "Nothing good on.");
            
            builder.AddWall("wall-beige", 1, 13, 1);
            builder.AddWall("wall-beige", currentPlan.Find("d0"));

            string m1 = "d9";
            string m2 = "d11";
            Util.Mutate2(ref m1, ref m2);

            var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), hallway.Find(m2).Right);
			builder.AddBlockMessage(Block.BlockMessage.REMOVE, currentPlan.Find("d0"), typeof(HouseHallwayOneRoom), hallway.Find(m2));

            var window = RoomPlans.Get(typeof(OutsideRoom).Name);
            builder.AddRoomTransition(typeof(OutsideRoom), currentPlan.Find("w"), window.Find("w").Left);
            builder.FillEdges();
        }
        
        public override void Update()
        {
            base.Update();
            if (isCutsceneTriggered)
                return;
                
            isCutsceneTriggered = true;
            CutsceneServant.Set(GameInfo.CurrentLevel, escapeCutscene);
        }
    }
}

