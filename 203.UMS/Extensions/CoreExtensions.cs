using System;

namespace _203.UMS.Extensions
{
    public static class CoreExtensions
    {
        public static long ToAbsolute(this object longInt)
        {
            var v = (long)longInt;
            return v == long.MinValue ? TimeSpan.MaxValue.Ticks : Math.Abs(v);
        }
    }
}
