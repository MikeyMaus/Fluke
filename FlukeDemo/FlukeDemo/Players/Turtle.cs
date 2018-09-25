using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Enums;
using FlukeDemo.ExtensionMethods;
using FlukeDemo.Interfaces;

namespace FlukeDemo.Players
{
    public class Turtle : Player
    {
        public Turtle(Direction startingDirection, Position startingPosition, IBoard board) : base(startingDirection, startingPosition, board)
        {

        }
    }
}
