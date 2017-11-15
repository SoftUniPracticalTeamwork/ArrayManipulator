namespace System
{
    using System.Linq;
    using System.Reflection;
    
    public static class MemberInfoExtensionMethods
    {
        public static bool ToLowerNameEquals(this Type type, string checkString)
        {
            return type.Name.ToLower().Equals(checkString);
        }

        public static bool LastCtorParameterEquals(this ConstructorInfo ctor, Type typeToCheckEqualityWith)
        {
            return ctor.GetParameters().Last().ParameterType == typeToCheckEqualityWith;
        }
    }
}
