using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo;
using FlukeDemo.MoveResults;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleTest
{
    [TestClass]
    public class BoardTests
    {
        private Board _sut;
        private List<Position> _mines;
        private Position _exit;
        [TestInitialize]
        public void Setup()
        {
            _mines = new List<Position>();
            _exit = new Position(2,2);
            _sut = new Board(3, 3, _exit, _mines);
        }

        [TestMethod]
        [Description("A player asking the board for the result of a move, should get success when standing on the exit")]
        public void Standing_On_Exit_Should_Return_Success()
        {
            var result = _sut.WhatIsPosition(new Position(2, 2));
            Assert.IsTrue(result is Success);
        }

        [TestMethod]
        [Description("A player on an empty field should get Still in Danger")]
        public void Standing_On_Nothing_Should_Return_StillInDanger()
        {
            var result = _sut.WhatIsPosition(new Position(0, 0));
            Assert.IsTrue(result is StillInDanger);
        }

        [TestMethod]
        [Description("A player on a mine should get covered in confetti")]
        public void Standing_On_A_Mine_Should_Return_MineHit()
        {
            _mines.Add(new Position(0, 0));
            var result = _sut.WhatIsPosition(new Position(0, 0));
            Assert.IsTrue(result is MineHit);
        }

        [TestMethod]
        [Description("A player off the board should have to swim back to the ladder")]
        public void Standing_Off_Board_Should_Return_Out_Of_Bounds()
        {
            var result = _sut.WhatIsPosition(new Position(5, 0));
            Assert.IsTrue(result is OutOfBounds);
        }
    }
}
