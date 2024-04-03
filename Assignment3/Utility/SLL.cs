using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable] // Generic class definition
    public class SLL<T> where T : IComparable<T> 
    {//  list nodes
        private class Node
        {// Data element 
            public T Data { get; set; } 
            public Node Next { get; set; }
            // Node constructor
            public Node(T data) 
            {
                Data = data;
                Next = null;
            }
        }

        private Node head; // Head node 
        private int count; 

        public SLL() // Constructor for SLL
        {
            head = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        // Appends a new element 
        public void Append(T data)
        {
            if (head == null) 
            {
                head = new Node(data);
            }
            else 
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(data);
            }
            count++;
        }

        
        public void Prepend(T data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
            count++;
        }

       
        public void InsertAt(int index, T data)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException("Index out of range");
            if (index == 0)
                Prepend(data);
            else
            {
                Node newNode = new Node(data);
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }
        }

        
        public void ReplaceAt(int index, T data)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index out of range");
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = data;
        }

        
        public int Count()
        {
            return count;
        }

       
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index out of range");
            if (index == 0)
                head = head.Next;
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
            count--;
        }

        public T GetAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index out of range");
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

       
        public int IndexOf(T data)
        {
            int index = 0;
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        
        public bool Contains(T data)
        {
            return IndexOf(data) != -1;
        }

        
        public void Reverse()
        {
            Node previous = null;
            Node current = head;
            Node next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            head = previous;
        }

       
        public void Sort()
        {
            if (count <= 1)
                return;

            bool swapped;
            do
            {
                swapped = false;
                Node current = head;
                Node previous = null;

                while (current.Next != null)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        T temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    previous = current;
                    current = current.Next;
                }
            } while (swapped);
        }

        
        public T[] ToArray()
        {
            T[] array = new T[count];
            Node current = head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
            return array;
        }

       
        public void Join(SLL<T> otherList)
        {
            if (otherList == null || otherList.IsEmpty())
                return;

            if (head == null)
            {
                head = otherList.head;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = otherList.head;
            }
            count += otherList.count;
            otherList.Clear(); 
        }

        
        public (SLL<T>, SLL<T>) Divide(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");

            SLL<T> firstHalf = new SLL<T>();
            SLL<T> secondHalf = new SLL<T>();

            Node current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex < index)
                    firstHalf.Append(current.Data);
                else
                    secondHalf.Append(current.Data);

                current = current.Next;
                currentIndex++;
            }

            return (firstHalf, secondHalf);
        }

        
        public void Serialize(string fileName)
        {
            try
            {
                using (FileStream stream = File.Create(fileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serialization error: " + ex.Message);
            }
        }

        
        public static SLL<T> Deserialize(string fileName)
        {
            try
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (SLL<T>)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deserialization error: " + ex.Message);
                return null;
            }
        }
    }
}
