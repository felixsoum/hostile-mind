using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    
    class HospitalLoganStart : Room
    {
        public const string CHAIR = "This is not the time to sit...";
        public const string BED = "Weird... this isn't my room.. it's Sandra's?";
        private Cutscene escapeCutscene;
        private bool isCutsceneTriggered = false;

        public HospitalLoganStart()
        {
            var builder = new RoomBuilder(this);

            var sandra = new SandraActor();
            sandra.Position = new Microsoft.Xna.Framework.Vector2(-100,-100);
            AddNpc(sandra);

            escapeCutscene = new HospitalGirlCutscene(sandra);
            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 8, 1);
            //Transitions/Objects
            builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR);
            builder.AddBlock("block-bed-test", currentPlan.Find("c1"), 1, triggerCutScene, "Read chart", "Leave");
            

            var hallway = RoomPlans.Get(typeof(Hospital5thFloorHallway).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorHallway), currentPlan.Find("d0"), hallway.Find("d0").Bottom);

            builder.FillEdges();
        }

        public void triggerCutScene(int i)
        {
            Dialog.SetText("What...? This is Sandra's room?", 2000);
            Dialog.SetText("What am I doing here?", 2000);
            isCutsceneTriggered = true;

        }

        public override void Update()
        {
            base.Update();
            if (isCutsceneTriggered)
            CutsceneServant.Set(GameInfo.CurrentLevel, escapeCutscene);
            isCutsceneTriggered = false;
            
            
        }
    }
}
