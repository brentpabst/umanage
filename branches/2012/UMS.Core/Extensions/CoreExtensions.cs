using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMS.Core.Extensions
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
