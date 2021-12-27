using System;

namespace Snake
{
    public class Position
    {
        public int Left { get; }
        public int Top { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public Position(int left, int top)
        {
            Left = left;
            Top = top;
        }

        /// <summary>
        /// overrides the tostring method.
        /// </summary>
        /// <returns>the position in the format of (num,num) </returns>
        public override string ToString()
        {
            return $"({Left},{Top})";
        }
    }
}