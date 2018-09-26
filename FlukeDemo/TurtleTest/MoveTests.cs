using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FlukeDemo;
using FlukeDemo.Enums;
using FlukeDemo.ExtensionMethods;
using FlukeDemo.Interfaces;
using FlukeDemo.MoveResults;
using FlukeDemo.Players;
using FlukeDemo.Players.PlayerMoves;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TurtleTest
{
    [TestClass]
    public class MoveTests
    {
        private IPlayer _player;
        private IBoard _board;   

        private Position _currentPosition;
        private Direction _currentDirection;

        [TestInitialize]
        public void Setup()
        {
            _board = Mock.Of<IBoard>();
            _player = Mock.Of<IPlayer>();
            Mock.Get(_board).Setup(d => d.Height).Returns(3);
            Mock.Get(_board).Setup(d => d.Width).Returns(3);
            Mock.Get(_board).Setup(d => d.WhatIsPosition(It.IsAny<Position>())).Returns(new StillInDanger());
            Mock.Get(_player).Setup(d => d.PlayBoard).Returns(_board);
            Mock.Get(_player).Setup(d => d.CurrentDirection).Returns(_currentDirection);
        }

        private void SetPosition(int x, int y)
        {
            _currentPosition = new Position(x, y);
            Mock.Get(_player).SetupGet(d => d.CurrentPosition).Returns(_currentPosition);
        }

        private void SetDirection(Direction direction)
        {
            _currentDirection = direction;
            Mock.Get(_player).SetupGet(d => d.CurrentDirection).Returns(_currentDirection);
        }

        [TestMethod]
        [Description("Starting in the top corner, moving South should return still in danger")]
        public void Move_South_From_Corner_Should_Return_Expected_Value()
        {
            SetPosition(0,0);
            SetDirection(Direction.South);
            Position updatedPosition = null;
            Mock.Get(_player).SetupSet(d => d.CurrentPosition = It.IsAny<Position>()).Callback<Position>(v => updatedPosition = v);
            var move = new StepForward();
            move.ExecuteMove(_player);

            Assert.AreEqual(updatedPosition, new Position(0,1));
        }

        [TestMethod]
        [Description("Starting in the top corner, moving north should return out of bounds")]
        public void Move_North_From_Corner_Should_Return_Expected_Value()
        {
            SetPosition(0, 0);
            SetDirection(Direction.North);
            Position updatedPosition = null;
            Mock.Get(_player).SetupSet(d => d.CurrentPosition = It.IsAny<Position>()).Callback<Position>(v => updatedPosition = v);
            var move = new StepForward();
            move.ExecuteMove(_player);

            Assert.AreEqual(updatedPosition, new Position(0, -1));
        }
    }
}
