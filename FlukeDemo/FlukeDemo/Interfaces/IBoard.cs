using System;
using System.Collections.Generic;
using System.Text;

namespace FlukeDemo.Interfaces
{
    public interface IBoard
    {
        int Width { get; }
        int Height { get; }
        IMoveResult WhatIsPosition(Position position);
    }
}
