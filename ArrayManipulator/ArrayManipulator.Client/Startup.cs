namespace ArrayManipulator.Client
{
    using ArrayManipulator.Core;
    using ArrayManipulator.Core.Interfaces;

    public class Startup
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
