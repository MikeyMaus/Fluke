using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Interfaces;

namespace FlukeDemo.MoveResults
{
    public class Success : IMoveResult
    {
        public bool IsGameEnder => true;
        public string Description => "You're a winner";
    }
}
