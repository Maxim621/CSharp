using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework4
{
    public class Plant
    {
        private int weight;
        private readonly Random random;

        public string Name { get; private set; }
        public bool IsPulledOut { get; private set; }

        public Plant(string name)
        {
            random = new Random();
            weight = random.Next(1, 10); // Вага рослини від 1 до 10
            Name = name;
            IsPulledOut = false;
        }

        public void Grow()
        {
            Console.WriteLine($"{Name} is growing...");
        }

        public void DecreaseWeight()
        {
            if (weight > 0)
            {
                weight--;
            }

            if (weight == 0)
            {
                IsPulledOut = true;
            }
        }
    }

    public class Turnip : Plant
    {
        public Turnip() : base("turnip")
        {
        }
    }

    public class Carrot : Plant
    {
        public Carrot() : base("carrot")
        {
        }
    }
}
