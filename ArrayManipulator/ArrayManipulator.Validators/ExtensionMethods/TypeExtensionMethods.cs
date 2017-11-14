namespace System
{
    public static class TypeExtensionMethods
    {
        public static bool NameEquals(this Type type, string checkString)
        {
            return type.Name.Equals(checkString);
        }
    }
}
