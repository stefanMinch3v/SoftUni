using System;

namespace AttributeShowing
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)] // it will restruct this attribute only to class or enum also we could add AllowMultiple = true if we want to add multiple Attributes
    public class AuthorAttribute : Attribute
    {
        //optionally put properties, constructors
    }
}
