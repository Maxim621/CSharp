namespace CSharp.Homework4.List
{
    public class List
    {
        private object[] items;
        private int count;
        private int capacity;

        public List()
        {
            capacity = 4; // Початкова ємність
            items = new object[capacity];
        }

        public List(int capacity)
        {
            this.capacity = capacity;
            items = new object[capacity];
        }

        public int Count
        {
            get { return count; }
        }

        public object this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public void Add(object item)
        {
            if (count == capacity)
            {
                ResizeArray();
            }

            items[count] = item;
            count++;
        }

        public void Insert(int index, object item)
        {
            if (count == capacity)
            {
                ResizeArray();
            }

            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            count++;
        }

        public bool Remove(object item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
            items[count] = null;
        }

        public void Clear()
        {
            Array.Clear(items, 0, count);
            count = 0;
        }

        public bool Contains(object item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public object[] ToArray()
        {
            object[] array = new object[count];
            Array.Copy(items, array, count);
            return array;
        }

        public void Reverse()
        {
            int left = 0;
            int right = count - 1;

            while (left < right)
            {
                object temp = items[left];
                items[left] = items[right];
                items[right] = temp;

                left++;
                right--;
            }
        }

        private void ResizeArray()
        {
            capacity *= 2;
            object[] newArray = new object[capacity];
            Array.Copy(items, newArray, count);
            items = newArray;
        }
    }
}
