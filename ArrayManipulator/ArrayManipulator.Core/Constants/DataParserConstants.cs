namespace ArrayManipulator.Core.Constants
{
    using System;

    public static class DataParserConstants
    {
        public static readonly Func<string, string[]> ParseFunc = s => s.Trim().Split();
    }
}
