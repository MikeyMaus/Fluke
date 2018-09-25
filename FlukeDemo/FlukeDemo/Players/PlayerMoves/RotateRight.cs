using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.ExtensionMethods;
using FlukeDemo.Interfaces;

namespace FlukeDemo.Players.PlayerMoves
{
    /// <summary>
    /// A simple 90 degree turn to the right
    /// </summary>
    public class RotateRight : IMove
    {
        public void ExecuteMove(IPlayer p)
        {
            p.CurrentDirection = p.CurrentDirection.RotateRight();
        }
    }
}
