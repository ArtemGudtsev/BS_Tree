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

            for(int i = 0; i < count; i++)
            {
                keys[i] = rnd.Next(0, int.MaxValue);
                values[i] = Convert.ToString(keys[i]);
            }

            return Tuple.Create(keys, values);
        }
    }
}
