using System;
using System.Collections.Generic;
namespace Queue
{
    class CustomQueue<T>
    {
        private T[] elements;
        private int front;
        private int rear;
        private int size;

        public CustomQueue()
        {
            elements = new T[2];
            front = 0;
            rear = -1;
            size = 0;
        }

        private void Resize()
        {
            T[] newElements = new T[elements.Length * 2];
            for (int i = 0; i < size; i++)
            {
                newElements[i] = elements[(front + i) % elements.Length];
            }
            front = 0;
            rear = size - 1;
            elements = newElements;
        }

        public void Enqueue(T item)
        {
            if (size == elements.Length)
            {
                Resize();
            }
            rear = (rear + 1) % elements.Length;
            elements[rear] = item;
            size++;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Очередь пуста");
            }

            T item = elements[front];
            front = (front + 1) % elements.Length;
            size--;

            return item;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Очередь пуста");
            }

            return elements[front];
        }

        public int Count()
        {
            return size;
        }
        public bool IsEmpty
        {
            get { return size == 0; }
        }
    }

    public class Queue1<T>
    {
        private List<T> elements = new List<T>();

        public void Enqueue(T item)
        {
            elements.Add(item);
        }

        public T Dequeue()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T item = elements[0];
            elements.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return elements[0];
        }

        public int Count()
        {
            return elements.Count;
        }

        public bool IsEmpty
        {
            get { return elements.Count == 0; }
        }
    }

}
