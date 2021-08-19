using System;

namespace Helio.Core
{
    public static class Utils
    {
        public static T Clamp<T>(T value, T min, T max) where T : IComparable
        {

            if (value.CompareTo(min) < 0)
            {
                return min;
            }
            if (value.CompareTo(max) > 0)
            {
                return max;
            }
            return value;
        }

        public static T Max<T>(T value1, T value2) where T : IComparable
        {
            if (value1.CompareTo(value2) > 0)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }
    }
}
