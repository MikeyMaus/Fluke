using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Enums;
using FlukeDemo.ExtensionMethods;
using FlukeDemo.Interfaces;

namespace FlukeDemo.Players.PlayerMoves
{
    //A simple step forwards, such as a tortoise might take
    public class StepForward : IMove
    {
        public void ExecuteMove(IPlayer p)
        {
            p.CurrentPosition = Move(p.CurrentPosition, p.CurrentDirection);
        }

        private Position Move(Position p, Direction d)
        {
            switch (d)
            {
                case Direction.North:
                    return new Position(p.X, p.Y - 1);
                case Direction.East:
                    return new Position(p.X + 1, p.Y);
                case Direction.South:
                    return new Position(p.X, p.Y + 1);
                case Direction.West:
                    return new Position(p.X - 1, p.Y);
                default:
                    throw new ArgumentOutOfRangeException(nameof(d), d, null);
            }
        }
    }
}
