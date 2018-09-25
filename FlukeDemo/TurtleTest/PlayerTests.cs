using System;
using System.Collections.Generic;
using System.Text;
using FlukeDemo;
using FlukeDemo.Enums;
using FlukeDemo.Interfaces;
using FlukeDemo.Players;
using FlukeDemo.Players.PlayerMoves;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleTest
{
    [TestClass]
    public class PlayerTests
    {
        private Turtle _sut;
        private List<IMove> _moves;
        private List<Position> _mines;

        [TestInitialize]
        public void Setup()
        {
            var exit = new Position(2, 2);
            _mines = new List<Position>();
            var start = new Position(0, 2);
            _sut = new Turtle(Direction.South, start, new Board(3,3, exit, _mines));
            _moves = new List<IMove>();
        }

        [TestMethod]
        [Description("Moves Should stop after hitting an exit")]
        public void Return_Success_After_Reaching_Exit_And_Stop_Processing_More_Moves()
        {
            _sut.CurrentDirection = Direction.East;
            _moves.Add(new StepForward());
            _moves.Add(new StepForward());
            _moves.Add(new BunnyHop());          //Not implemented, but should never trigger

            var finalMove = _sut.ProcessMoves(_moves);
            Assert.AreEqual(finalMove, MoveResult.Success);
        }

        [TestMethod]
        [Description("Moves Should stop after hitting a mine")]
        public void Return_Mine_After_Hitting_Mine_And_Stop_Processing_More_moves()
        {
            _sut.CurrentDirection = Direction.East;
            _mines.Add(new Position(1,2));
            _moves.Add(new StepForward());
            _moves.Add(new StepForward());
            _moves.Add(new StepForward());
            _moves.Add(new StepForward());

            var finalMove = _sut.ProcessMoves(_moves);
            Assert.AreEqual(finalMove, MoveResult.MineHit);
        }


    }
}
