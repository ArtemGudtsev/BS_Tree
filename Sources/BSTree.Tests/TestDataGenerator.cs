using System;

namespace BSTree.Tests
{
    public class TestDataGenerator
    {
        public static Tuple<int[], string[]> GetKeysAndValues()
        {
            return GetKeysAndValues(10);
        }

        public static Tuple<int[], string[]> GetKeysAndValues(int count)
        {
            int[] keys = new int[count];
            string[] values = new string[count];
            Random rnd = new Random();
            int max = int.MaxValue / 4 < count ? count * 4 : count;

            for(int i = 0; i < count; i++)
            {
                int v = rnd.Next(1, max);
                keys[i] = v;
                values[i] = Convert.ToString(v);
            }

            return Tuple.Create(keys, values);
        }
    }
}
