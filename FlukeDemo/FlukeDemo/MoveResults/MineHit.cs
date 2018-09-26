using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Interfaces;

namespace FlukeDemo.MoveResults
{
    public class MineHit : IMoveResult
    {
        public bool IsGameEnder => true;
        public string Description => "Boom, lucky it's only a confetti mine";
    }
}
