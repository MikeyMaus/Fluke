using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlukeDemo
{
    public enum MoveResult
    {
        [Description("You're a winner")]
        Success,
        [Description("Boom, lucky it's only a confetti mine")]
        MineHit,
        [Description("You're not at the end yet, keep going")]
        StillInDanger,
        [Description("You fell into the water, swim back to the ladder")]
        OutOfBounds
    }
}
