using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlukeDemo.Enums;
using FlukeDemo.ExtensionMethods;
using FlukeDemo.Interfaces;

namespace FlukeDemo.Players
{
    public abstract class Player : IPlayer
    {
        protected Player(Direction startingDirection, Position startingPosition, IBoard board)
        {
            CurrentDirection = startingDirection;
            CurrentPosition = startingPosition;
            PlayBoard = board;
        }

        public Direction CurrentDirection { get; set; }
        public Position CurrentPosition { get; set; }
        public IBoard PlayBoard { get; set; }

        public MoveResult ProcessMoves(IEnumerable<IMove> moves)
        {
            var listOfMoves = GetMoves(moves);
            var finalMove = listOfMoves.Last();
            return finalMove;
        }

        private IEnumerable<MoveResult> GetMoves(IEnumerable<IMove> moves)
        {
            foreach (var m in moves)
            {
                var currentPosition = PlayBoard.WhatIsPosition(CurrentPosition);
                if (currentPosition.IsGameEnder())
                {
                    yield return currentPosition;
                    yield break;
                }

                m.ExecuteMove(this);
                yield return currentPosition;
            }
        }

    }
}
