using System;
using System.Collections.Generic;
using System.Text;

namespace FlukeDemo.Interfaces
{
    public interface IMoveResult
    {
        bool IsGameEnder { get; }
        string Description { get; }
    }
}
