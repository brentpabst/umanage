[assembly: WebActivator.PreApplicationStartMethod(typeof(uManage.App_Start.SquishItLess), "Start")]

namespace uManage.App_Start
{
    using SquishIt.Framework;
    using SquishIt.Less;

    public class SquishItLess
    {
        public static void Start()
        {
            Bundle.RegisterStylePreprocessor(new LessPreprocessor());
        }
    }
}