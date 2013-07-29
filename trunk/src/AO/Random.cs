namespace THS.UMS.AO
{
    using System;
    using System.Linq;

    public static class Random
    {
        private static readonly System.Random Rand = new System.Random();

        public static T RandomEnumValue<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().OrderBy(x => Rand.Next()).FirstOrDefault();
        }

        public static int RandomNumber(int min, int max)
        {
            return Rand.Next(min, max);
        }
    }
}
