namespace ArrayManipulator.Client
{
    using ArrayManipulator.CommandInterpreter;
    using ArrayManipulator.CommandInterpreter.Interfaces;
    using ArrayManipulator.Commands.Constants;
    using ArrayManipulator.Core;
    using ArrayManipulator.Core.Constants;
    using ArrayManipulator.Core.Interfaces;
    using ArrayManipulator.IO;
    using ArrayManipulator.IO.Interfaces;

    public class Startup
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IArrayCommandConventionBuilder conventionBuilder = new ArrayCommandConventionBuilder(CommandConstants.CommandSuffix, 
                                                                                                 CommandConstants.LastCtorType);
            IArrayCommandInterpreter commandInterpreter = new ArrayCommandInterpreter(conventionBuilder);
            IDataParser dataParser = new DataParser(DataParserConstants.ParseFunc);

            IEngine engine = new Engine(reader,
                                        writer, 
                                        commandInterpreter, 
                                        dataParser);
            engine.Run();
        }
    }
}
