using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{

    public class Lever
    {
        public bool on;
        public string name;
        
        public Lever(string n, LightSource l)
        {
            this.on = true;
            this.name = n;
        }

        public void toggleLever(){
            if (this.on)
            {
                on = false;
            }
            else
            {
                on = true;
            }
        }
    }
    
    
    class HospitalBasementSwitchRoom : Room
    {
        private HospitalBasementHallway hallway;
        RoomBuilder builder;
        int lightCounter = 0;
        List<Lever> levers;
        List<LightSource> lights2;

        public HospitalBasementSwitchRoom()
        {

            builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            //builder.AddWall("wall-hospital", 1, 8, 1);

            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);
            var bhallway = RoomPlans.Get(typeof(HospitalBasementHallway).Name);
            builder.AddRoomTransition(typeof(HospitalBasementHallway), currentPlan.Find("d0"), bhallway.Find("d2").Left);
     

            builder.FillEdges();

        }

        public override void OnRoomCreation(Level level)
        {
            hallway = level.GetRoom<HospitalBasementHallway>(typeof(HospitalBasementHallway));
            lights2 = hallway.returnLights();
            levers = new List<Lever>(7);

            for (int i = 0; i < 7; i++)
            {
                string name = "s" + (i + 1) + "";
                Lever temp = new Lever(name, lights2[i]);
                levers.Add(temp);
            }
        }

        public override void Update()
        {
            base.Update();

            for (int i = 0; i < 7; i++)
            {
                
                if (levers[i].on)
                {
                    int temp = i;
                    builder.ClearOnStep(currentPlan.Find(levers[i].name));
                    builder.AddBlock("h-wall-switch", currentPlan.Find(levers[i].name), 1, x => toggle(x,temp), "Switch Lever", "Leave");
                }
                else
                {
                    int temp = i;
                    builder.ClearOnStep(currentPlan.Find(levers[i].name));
                    builder.AddBlock("h-wall-switch-down", currentPlan.Find(levers[i].name), 1, x => toggle(x, temp), "Switch Lever", "Leave");
                }
            }

            calcLights();
        }

        public void toggle(int choice, int i)
        {
            if (choice == 1)
            {
                Dialog.SetText("You flip the switch");
                levers[i].toggleLever();
            }
        }

        public void calcLights()
        {
            if (levers[5].on == false){
                lights2[2].toggleLightSource(false);
            }else{
                lights2[2].toggleLightSource(true);
            }
            if (levers[2].on == true){
                lights2[3].toggleLightSource(false);
            }else{
                lights2[3].toggleLightSource(true);
            }
            if (levers[0].on == false && levers[4].on == true){
                lights2[4].toggleLightSource(false);
            }else{
                lights2[4].toggleLightSource(true);
            }
            if (levers[3].on == true && levers[6].on == false)
            {
                lights2[5].toggleLightSource(false);
            }
            else
            {
                lights2[5].toggleLightSource(true);
            }
            if (levers[1].on == false && levers[6].on == false)
            {
                lights2[6].toggleLightSource(false);
            }
            else
            {
                lights2[6].toggleLightSource(true);
            }

        }


    }
}
