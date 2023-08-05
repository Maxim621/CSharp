using System;

namespace CSharp.Homework8.Bank
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MenuItemAttribute : Attribute
    {
        public string Title { get; }

        public MenuItemAttribute(string title)
        {
            Title = title;
        }
    }
}
