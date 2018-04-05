using System;

namespace HostileMind
{
    public class FinalCasePeel : Room
    {
        private const string ROCK_TEXT = "These rocks are everywhere...";

        public FinalCasePeel()
        {
            //

            var builder = new RoomBuilder(this);

            //FLOOR

            builder.FillFloor("floor-platform-Peel");
            //safety line
            builder.FillFloor("floor-safety-line", currentPlan.Find("l0"), 67, 1); //88
            builder.FillFloor("floor-safety-line", currentPlan.Find("l1"), 67, 1);
            //tracks
            builder.FillFloor("floor-htracks", currentPlan.Find("f0"), 68, 5); //90
            builder.FillFloor("floor-htracks", currentPlan.Find("f1"), 68, 5);
            //concrete
            builder.FillFloor("floor-hstairs", currentPlan.Find("cs0"), 1, 1);
            builder.FillFloor("floor-hstairs", currentPlan.Find("cs1"), 1, 1);
            //stairs
            builder.FillFloor("floor-hstairs", currentPlan.Find("s0"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s1"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s2"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s3"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s4"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s5"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s6"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s7"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s8"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s9"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s10"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s11"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s12"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s13"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s14"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s15"), 2, 4);

            //WALLs
            
            builder.AddWall("wall-peel", 8, 11, 2); //back left
            builder.AddWall("wall-peel", 58, 61, 2); // back right
            builder.AddWall("wall-peel", 31, 33, 2);//center
            builder.AddWall("wall-peel", 36, 38, 2);//center
            builder.AddWall("wall-peel-circle", 34, 35, 2);//center circle
            //peel wall on right
            builder.AddWall("wall-peel1", 62, 63, 12);
            builder.AddWall("wall-peel2", 64, 65, 12);
            builder.AddWall("wall-peel3", 66, 67, 12);
            //peel wall on left
            builder.AddWall("wall-peel1", 2, 3, 12);
            builder.AddWall("wall-peel2", 4, 5, 12);
            builder.AddWall("wall-peel3", 6, 7, 12);
            //front right
            builder.AddWall("wall-peel1", 42, 43, 12);
            builder.AddWall("wall-peel2", 44, 45, 12);
            builder.AddWall("wall-peel3", 46, 47, 12);
            builder.AddWall("wall-peel", 48, 48, 12);
            builder.AddWall("wall-peel1", 49, 50, 12);
            builder.AddWall("wall-peel2", 51, 52, 12);
            builder.AddWall("wall-peel3", 53, 54, 12);
            //front left
            builder.AddWall("wall-peel1", 15, 16, 12);
            builder.AddWall("wall-peel2", 17, 18, 12);
            builder.AddWall("wall-peel3", 19, 20, 12);
            builder.AddWall("wall-peel", 21, 21, 12);
            builder.AddWall("wall-peel1", 22, 23, 12);
            builder.AddWall("wall-peel2", 24, 25, 12);
            builder.AddWall("wall-peel3", 26, 27, 12);

            //BLOCKS

            foreach (var p in currentPlan.FindAll("p"))
                builder.AddPushableBlock("stone-brown", p);
            foreach (var r in currentPlan.FindAll("r"))
                builder.AddBlock("block-debris", r, 1, ROCK_TEXT);
            //fires
            foreach (var f in currentPlan.FindAll("f"))
                builder.AddFire(f, Item.ItemType.EXTINGUISHER, "I can't pass this fire.", "block-fire");

            //ITEMS
            builder.AddItemTile(Item.ItemType.EXTINGUISHER, currentPlan.Find("ex1"));

            //EVENTS

            foreach (var e0 in currentPlan.FindAll("e0"))
                builder.AddDialogToTile( "I smell fire", e0);

            //TRANSITIONS

            //back to concordia-2
            var cp = RoomPlans.Get(typeof(FinalCaseConcordiaPeel).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordiaPeel), currentPlan.Find("d0"), cp.Find("d1").Left);

            //to peel-mcgill 
            //var pm = RoomPlans.Get(typeof(FinalCasePeelMcgill).Name);
            //builder.AddRoomTransition(typeof(FinalCasePeelMcgill), currentPlan.Find("d1"), pm.Find("d0").Right);

            //to end the level, logan steps on room index "d1"
            //add whatever here

            //builder.FillEdges();

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

        }
    }
}
