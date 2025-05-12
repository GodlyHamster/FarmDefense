using System;

public static class TypeExtension
{
    public static bool IsSubclassOf(this Type type, Type parent, bool isGenericType)
    {
        if (type == null) return false;

        type = isGenericType && type.IsGenericType ? type.GetGenericTypeDefinition() : type;
        
        if (type == parent) return true;

        return IsSubclassOf(type.BaseType, parent, isGenericType);
    }
}
