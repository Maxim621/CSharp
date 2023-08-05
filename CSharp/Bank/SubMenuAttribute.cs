using System;

namespace CSharp.Homework8.Bank
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SubMenuAttribute : Attribute
    {
        public string Title { get; }

        public SubMenuAttribute(string title)
        {
            Title = title;
        }
    }
}
