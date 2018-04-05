using System;

namespace HostileMind
{
    public static class Util
    {
        private static Random random = new Random();
        private static int seed1 = 0;
        private static int seed2 = 0;
        private static int seed3 = 0;

        public static void Seed()
        {
            seed1 = random.Next(2);
            seed2 = random.Next(2);
            seed3 = random.Next(2);
        }

        public static void Mutate1(ref string s1, ref string s2)
        {
            if (seed1 == 0)
                return;

            var t = s1;
            s1 = s2;
            s2 = t;
        }

        public static void Mutate2(ref string s1, ref string s2)
        {
            if (seed2 == 0)
                return;

            var t = s1;
            s1 = s2;
            s2 = t;
        }

        public static void Mutate3(ref string s1, ref string s2)
        {
            if (seed3 == 0)
                return;

            var t = s1;
            s1 = s2;
            s2 = t;
        }
    }
}

