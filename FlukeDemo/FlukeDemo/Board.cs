using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlukeDemo.Enums;
using FlukeDemo.ExtensionMethods;
using FlukeDemo.Interfaces;
using FlukeDemo.MoveResults;

namespace FlukeDemo
{
    public class Board : IBoard
    {
        public int Width { get; }
        public int Height { get;}

        private readonly Position _exitPosition;
        private readonly IEnumerable<Position> _mines;

        public Board(int width, int height, Position exit, IEnumerable<Position> mines)
        {
            Width = width;
            Height = height;
            _exitPosition = exit;
            _mines = mines;
        }

        public IMoveResult WhatIsPosition(Position position)
        {
            if (position == _exitPosition) return new Success();
            if (_mines.Any(d => d == position)) return new MineHit();
            if (position.X < 0 || position.Y < 0) return new OutOfBounds();
            if (position.X > Width || position.Y > Height) return new OutOfBounds();
            return new StillInDanger();
        }
    }
}
