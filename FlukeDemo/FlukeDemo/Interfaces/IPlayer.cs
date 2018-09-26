using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Enums;

namespace FlukeDemo.Interfaces
{
    public interface IPlayer
    {
        Direction CurrentDirection { get; set; }
        Position CurrentPosition { get; set; }

        IBoard PlayBoard { get; set; }

        IMoveResult ProcessMoves(IEnumerable<IMove> moves);
    }
}
