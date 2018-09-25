using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Enums;

namespace FlukeDemo.ExtensionMethods
{
    public static class MoveResults
    {
        public static bool IsGameEnder(this MoveResult r)
        {
            return r == MoveResult.OutOfBounds || r == MoveResult.MineHit || r == MoveResult.Success;
        }
    }
}
