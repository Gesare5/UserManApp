using System;

namespace MyUserManagementApp
{
    public class UserQueue<T>
    {
        public NodeStructure<T> Head { get; set; }
        public NodeStructure<T> Tail { get; set; }
        public int Count { get; set; }

         //Queue -> First in first out. Add to the bottom [Enqueue], remove from the top [Dequeue]

        //  this method adds new node to the bottom

        public NodeStructure<T> Enqueue(T value)
        {
            NodeStructure<T> node = new NodeStructure<T>(value);

            if (this.Head == null)
            {
                Head = Tail = node;
                this.Count++;
                return node;
            }

            // sets the new node as the new tail
            this.Tail.Next = node;
            this.Tail = node;
            this.Count++;
            return node;
        }


         // this method removes from the top
         public T Dequeue()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            
            T value = this.Head.Value;
            this.Head = this.Head.Next;
            this.Count--;
            return value;
        }

        // this method prints out all present nodes

         public void Print()
        {
            var temp = Head;
            while (temp != null)
            {
                System.Console.WriteLine(temp.Value);
                temp = temp.Next;
            }
        }
    }
}