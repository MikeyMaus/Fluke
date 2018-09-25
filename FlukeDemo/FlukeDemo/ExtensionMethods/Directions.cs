using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo.Enums;

namespace FlukeDemo.ExtensionMethods
{
    public static class DirectionExtensions
    {
        public static Direction RotateRight(this Direction d)
        {
            return (Direction)(((int)d + 1) % 4);
        }
    }
}
