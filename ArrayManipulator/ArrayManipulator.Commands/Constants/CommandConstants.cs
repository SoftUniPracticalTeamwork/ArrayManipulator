namespace ArrayManipulator.Commands.Constants
{
    using System;
    
    public static class CommandConstants
    {
        public const string CommandSuffix = "Command";
        public static readonly Type LastCtorType = typeof(string[]);

        public const string InvalidParametersMessage = "Error: invalid command parameters";
        
        public const string InvalidIndexFormatMessage = "Error: invalid index {0}";
    }
}
