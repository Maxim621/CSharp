namespace CSharp.Homework4
{
    public class RipkaStory
    {
        public static void Ripka()
        {
            // Створюємо персонажі та за бажанням додаємо ще персонажів
            List<Person> characters = new List<Person>
        {
            new Person("Grandpa"),
            new Person("Grandma"),
            new Person("Grandchild"),
            new Person("Doggo")
        };

            // Створюємо різні рослини
            List<Plant> plants = new List<Plant>
        {
            new Turnip(),
            new Carrot()
        };

            // Вибираємо рандомну рослину
            Random random = new Random();
            Plant chosenPlant = plants[random.Next(plants.Count)];

            // Дід садить рослину
            characters[0].Plant(chosenPlant);

            // Поки рослину не витягнуто і є ще персонажі, продовжуємо витягувати
            int characterIndex = 0;
            while (!chosenPlant.IsPulledOut && characterIndex < characters.Count)
            {
                Person character = characters[characterIndex];

                // Персонаж намагається витягнути рослину
                character.Pull(chosenPlant);

                // Якщо персонаж витягнув рослину
                if (chosenPlant.IsPulledOut)
                {
                    Console.WriteLine($"{character.Name} pulled out the {chosenPlant.Name}!");
                }
                // Якщо рослину не вдалося витягнути, переходимо до наступного персонажа
                else
                {
                    Console.WriteLine($"{character.Name} calls for help!");
                    characterIndex++;
                }
            }

            // Якщо всі персонажі спробували витягнути рослину, але вона залишилась невитягнутою
            if (!chosenPlant.IsPulledOut && characterIndex >= characters.Count)
            {
                Console.WriteLine($"The plant couldn't be pulled out. It was too heavy");
            }
        }
    }
}