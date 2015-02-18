using System;

namespace uManage.Directories.ActiveDirectory
{
    internal static class Helpers
    {
        internal static long ToAbsolute(this object longInt)
        {
            var v = (long)longInt;
            return v == long.MinValue ? TimeSpan.MaxValue.Ticks : Math.Abs(v);
        }
    }
}
