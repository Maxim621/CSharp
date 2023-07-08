namespace CSharp.Homework4.StackFolder
{
    public class Stack
    {
        private object[] data;
        private int top;

        public Stack()
        {
            data = new object[100]; // Початковий розмір масиву
            top = -1; // Початковий індекс вершини стека
        }

        public void Clear()
        {
            top = -1; // Очищаємо стек шляхом встановлення індексу вершини на початкове значення
        }

        public bool Contains(object item)
        {
            for (int i = 0; i <= top; i++)
            {
                if (data[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public object Peek()
        {
            if (top >= 0)
            {
                return data[top]; // Повертаємо елемент з вершини стека, не видаляючи його
            }
            throw new InvalidOperationException("Stack is empty.");
        }

        public object[] ToArray()
        {
            object[] array = new object[top + 1];
            Array.Copy(data, array, top + 1);
            return array;
        }

        public void Push(object item)
        {
            if (top == data.Length - 1)
            {
                // Якщо масив заповнений, збільшуємо його розмір вдвічі
                object[] newData = new object[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            top++;
            data[top] = item; // Додаємо новий елемент на вершину стека
        }

        public object Pop()
        {
            if (top >= 0)
            {
                object item = data[top]; // Зберігаємо елемент з вершини стека
                top--; // Зменшуємо індекс вершини стека
                return item;
            }
            throw new InvalidOperationException("Stack is empty.");
        }

        public int Count
        {
            get { return top + 1; } // Кількість елементів в стеці
        }
    }
}
