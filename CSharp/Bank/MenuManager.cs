using System;
using System.Collections.Generic;

namespace CSharp.Homework8.Bank
{
    public class MenuManager
    {
        private Dictionary<int, Action> menuItems;
        private Stack<Action> menuStack;

        public MenuManager()
        {
            menuItems = new Dictionary<int, Action>();
            menuStack = new Stack<Action>();
        }

        public void AddMenuItem(int option, Action action)
        {
            menuItems.Add(option, action);
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                foreach (var item in menuItems)
                {
                    var attribute = item.Value.Method.GetCustomAttributes(typeof(MenuItemAttribute), false);
                    if (attribute.Length > 0)
                    {
                        var menuItem = attribute[0] as MenuItemAttribute;
                        Console.WriteLine($"{item.Key}. {menuItem.Title}");
                    }
                }

                if (menuStack.Count > 0)
                {
                    Console.WriteLine("0. Back");
                }
                else
                {
                    Console.WriteLine("0. Exit");
                }

                Console.Write("Enter option: ");
                var input = Console.ReadLine();
                int option;
                if (int.TryParse(input, out option))
                {
                    if (option == 0)
                    {
                        if (menuStack.Count > 0)
                        {
                            var prevMenu = menuStack.Pop();
                            prevMenu.Invoke();
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (menuItems.ContainsKey(option))
                    {
                        var selectedAction = menuItems[option];
                        var attribute = selectedAction.Method.GetCustomAttributes(typeof(SubMenuAttribute), false);
                        if (attribute.Length > 0)
                        {
                            menuStack.Push(selectedAction);
                        }
                        selectedAction.Invoke();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
