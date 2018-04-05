using System;
using System.Collections.Generic;

namespace HostileMind
{
    public class RoomPlan
    {
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        private IDictionary<string, List<RoomIndex>> symbolHits = new Dictionary<string, List<RoomIndex>>();

        public RoomPlan()
        {
            ColumnCount = 0;
            RowCount = 0;
        }

        public void AddSymbol(string s, int i, int j)
        {
            List<RoomIndex> list;

            if (!symbolHits.TryGetValue(s, out list))
            {
                list = new List<RoomIndex>();
                symbolHits.Add(s, list);
            }
            list.Add(new RoomIndex(i, j));
        }

        public RoomIndex Find(string s)
        {
            List<RoomIndex> list;
            symbolHits.TryGetValue(s, out list);
            return list[0];
        }

        public List<RoomIndex> FindAll(string s)
        {
            List<RoomIndex> list;
            symbolHits.TryGetValue(s, out list);
            return list;
        }
    }
}

