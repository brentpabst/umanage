using System;

namespace _203E.UMS.Extensions
{
    public static class Structs
    {
        public static long ToAbsolute(this object longInt)
        {
            var v = (long)longInt;
            return v == long.MinValue ? TimeSpan.MaxValue.Ticks : Math.Abs(v);
        }
    }
}
