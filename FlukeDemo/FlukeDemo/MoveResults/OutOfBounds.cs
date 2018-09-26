using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Interfaces;

namespace FlukeDemo.MoveResults
{
    public class OutOfBounds : IMoveResult
    {
        public bool IsGameEnder => true;
        public string Description => "You fell into the water, swim back to the ladder";
    }
}
