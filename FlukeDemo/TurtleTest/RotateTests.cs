using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo;
using FlukeDemo.Enums;
using FlukeDemo.ExtensionMethods;
using FlukeDemo.Interfaces;
using FlukeDemo.Players.PlayerMoves;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TurtleTest
{
    [TestClass]
    public class RotateTests
    {
        private RotateRight _sut;
        private IPlayer _player;
        
        [TestInitialize]
        public void Setup()
        {
            _sut = new RotateRight();
            _player = Mock.Of<IPlayer>();
            Mock.Get(_player).SetupSet(d => d.CurrentDirection = It.IsAny<Direction>());
        }

        [TestMethod]
        [Description("If a North facing turtle rotates to the right, it should be facing east")]
        public void Rotate_North_Should_Result_In_East()
        {
            Mock.Get(_player).Setup(d => d.CurrentDirection).Returns(Direction.North);
            _sut.ExecuteMove(_player);
            Mock.Get(_player).VerifySet(d => d.CurrentDirection = Direction.East);
        }

        [TestMethod]
        [Description("If a West facing turtle rotates to the right, it should be facing North")]
        public void Rotate_West_Should_Result_In_North()
        {
            Mock.Get(_player).Setup(d => d.CurrentDirection).Returns(Direction.West);
            _sut.ExecuteMove(_player);
            Mock.Get(_player).VerifySet(d => d.CurrentDirection = Direction.North);
        }
    }
}
