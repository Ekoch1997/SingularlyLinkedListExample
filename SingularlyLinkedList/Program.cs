

namespace Tutorial
{
    public class Node
    {
        private object data;
        private Node next;

        public Node(object data, Node next)
        {
            this.data = data;
            this.next = next;
        }

        public object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }

    public class LinkedList
    {
        private Node head; //reference to the first node in the list
        private int count;

        public LinkedList() //Constructor, this is how it is initialized
        {
            this.head = null;
            this.count = 0;
        }


        public bool Empty
        {
            get { return this.count == 0; }
        }

        public int Count
        {
            get { return this.count; }
        }

        public object Add(int index, object o)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index: " + index);

            if (index > count)
                index = count;

            Node current = this.head;

            if (this.Empty || index == 0)
            {
                this.head = new Node(o, this.head);
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = new Node(o, current.Next); //Create a new node at the end of the linked list
            }
            count++;

            return o;
        }

        public object Add(object o)
        {
            return this.Add(count, o);
        }

        public object AddToFront(object o)
        {
            this.head = new Node(o, this.head);
            count++;
            return o;
        }

        public object RemoveFromFront(object o)
        {
            this.head = this.head.Next;
            count--;

            return o;
        }

        public object Remove(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index: " + index);

            if (this.Empty)
                return null;

            if (index >= count)
                index = count - 1;

            Node current = this.head;
            object result = null;


            if (index == 0)
            {
                result = current.Data;
                this.head = current.Next;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                result = current.Next.Data;
                current.Next = current.Next.Next;
            }

            count--;
            return result;
        }

        public void Clear()
        {
            this.head = null;
            this.count = 0;
        }

        public void Print()
        {
            Node current = this.head;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void Remove()
        {
            this.Remove(count);
        }

        public int IndexOf(object o)
        {
            Node current = this.head;

            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(o))
                    return i;
                current = current.Next;
            }
            return -1;
        }

        public bool Contains(object o)
        {
            return this.IndexOf(o) >= 0;
        }

        public object Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index: " + index);

            if (index >= count)
                index = count - 1;

            Node current = this.head;

            for (int i = 0; i < index; ++i)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public object this[int index]
        {
            get { return this.Get(index); }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.Add("Test1");
            list.Add("Test2");
            list.Add(1, "Test3");
            list.AddToFront("TestFront");
            list.Remove(2);
            list.Print();

            Console.WriteLine(list[2]);

            Console.WriteLine(list.Empty);
            Console.WriteLine(list.Count);
            Console.ReadKey();
        }
    }
}

