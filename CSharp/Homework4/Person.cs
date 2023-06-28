using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework4
{
    public class Person
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        public void Plant(Plant plant)
        {
            Console.WriteLine($"{Name} plants {plant.Name}.");
            plant.Grow();
        }

        public void Pull(Plant plant)
        {
            if (!plant.IsPulledOut)
            {
                Console.WriteLine($"{Name} tries to pull {plant.Name}.");
                plant.DecreaseWeight();
            }
        }
    }
}
