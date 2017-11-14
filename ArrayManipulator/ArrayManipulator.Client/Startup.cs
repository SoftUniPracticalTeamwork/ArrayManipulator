namespace ArrayManipulator.Client
{
    using ArrayManipulator.CommandInterpreter;
    using ArrayManipulator.CommandInterpreter.Interfaces;
    using ArrayManipulator.Commands.CommandResult.Interfaces;
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
