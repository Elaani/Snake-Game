using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class CircularQueue
    {
        public int front;
        public int rear;
        private int n;
        private int capacity;
        private Position[] elements;

        public CircularQueue(int capacity)
        {
            this.capacity = capacity;
            this.elements = new Position[capacity];
            n = 0;
            front = -1;
            rear = -1;
        }

        /// <summary>
        /// Determines whether this queue is empty.
        /// </summary>
        /// <returns>True if queue is empty.</returns>
        public bool Empty()
        {
            return n == 0;
        }

        /// <summary>
        /// Determines whether this queue is full.
        /// </summary>
        /// <returns>True if queue is full.</returns>
        public bool Full()
        {
            return n == capacity;
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="p"></param>
        public void Enqueue(Position p)
        {
            if (Full())
                throw new InvalidOperationException("Can't add an element to a full queue.");

            rear = ++rear % capacity;
            elements[rear] = p;

            if (Empty())
                front = rear;

            n++;
        }

        /// <summary>
        /// returns the rear element
        /// </summary>
        /// <returns></returns>
        public Position GetRear()
        {
            Position remove = elements[rear];

            return remove;
        }

        /// <summary>
        /// removes the first element from the queue
        /// </summary>
        /// <returns>the number removed from queue, or throws exception if empty</returns>
        public Position Dequeue()
        {
            if (Empty())
                throw new InvalidOperationException("Can't remove an element from an empty queue.");

            Position p = elements[front];
            elements[front] = null;
            n--;
            if (!Empty())
                front = ++front % capacity;
            return p;
        }

        /// <summary>
        /// overrides tostring method
        /// </summary>
        /// <returns>the string in the form of {sb.ToString()} n:{n} front:{front} rear:{rear}</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = front; i < front + n; i++)
            {
                sb.Append(elements[i % capacity]).Append(" ");
            }

            return $"{sb.ToString()} n:{n} front:{front} rear:{rear}";
        }
    }
}
