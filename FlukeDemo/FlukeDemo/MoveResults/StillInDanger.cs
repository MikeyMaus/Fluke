using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Interfaces;

namespace FlukeDemo.MoveResults
{
    public class StillInDanger : IMoveResult
    {
        public bool IsGameEnder => false;
        public string Description => "You're not at the end yet, keep going";
    }
}
