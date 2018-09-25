using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlukeDemo.Enums;
using FlukeDemo.Interfaces;
using FlukeDemo.Players;
using FlukeDemo.Players.PlayerMoves;
using FlukeDemo.ExtensionMethods;

namespace FlukeDemo
{
    public class Game
    {
        private readonly IPlayer _player;
        private readonly List<IMove> _moves;

        public Game(IPlayer player, List<IMove> moves)
        {
            _player = player;
            _moves = moves;
        }

        public void Play()
        {
            var result = _player.ProcessMoves(_moves);
            Console.WriteLine(result.GetDescription());
        }
    }
}
