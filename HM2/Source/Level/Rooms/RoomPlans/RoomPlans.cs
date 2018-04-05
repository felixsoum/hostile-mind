using System;
using System.Collections.Generic;
using System.IO;

namespace HostileMind
{
    public static class RoomPlans
    {
        private static IDictionary<string, RoomPlan> roomPlans = new Dictionary<string, RoomPlan>();
        private static char[] delimiterChars = new char[] { '\t' };

        public static void Load()
        {
            string[] files = Directory.GetFiles(@".\Content\RoomPlans");
            foreach (var file in files)
            {
//                Console.WriteLine(file);
                var roomPlan = new RoomPlan();
                using (var reader = new StreamReader(file))
                {
                    string line;
                    int j = 0;
                    while ((line = reader.ReadLine()) != null)
                    {

                        int i = 0;
                        string[] words = line.Split(delimiterChars);
                        foreach (var w in words)
                        {
                            roomPlan.AddSymbol(w, i, j);
                            i++;
                        }
                        roomPlan.ColumnCount = i;
                       j++;
                    }
                    roomPlan.RowCount = j;
                }
                roomPlans.Add(Path.GetFileNameWithoutExtension(file), roomPlan);
            }
        }

        public static RoomPlan Get(string name)
        {
            RoomPlan roomPLan;
            if (roomPlans.TryGetValue(name, out roomPLan))
                return roomPLan;

            return null;
        }
    }
}

