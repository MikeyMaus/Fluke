using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Enums;

namespace FlukeDemo
{
    public sealed class Position : IEquatable<Position>
    {
        public readonly int X;
        public readonly int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Position p1, Position p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (ReferenceEquals(p1, null))
            {
                return false;
            }
            if (ReferenceEquals(p2, null))
            {
                return false;
            }

            return (p1.X == p2.X && p1.Y == p2.Y);
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Position position && Equals(position);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
