using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text.RegularExpressions;
using FlukeDemo.Enums;
using FlukeDemo.Interfaces;
using FlukeDemo.Players;
using FlukeDemo.Players.PlayerMoves;

namespace FlukeDemo
{
    /// <summary>
    /// Am ugly parsing class, hopefully it'll be replaced with something a little more robust in the next version
    /// </summary>
    public class TextFileReader
    {
        private readonly List<string> _fileLines;
        private const string MoveCommand = "m";
        private const string RotateCommand = "r";


        public TextFileReader(string fileUrl)
        {
            var lines = File.ReadLines(fileUrl);
            _fileLines = lines.ToList();
        }

        public Game LoadFileGame()
        {
            var parsedGridSize = GetGridSize(_fileLines.First());
            var parsedStartingData = GetStartingPositionAndDirection(_fileLines.Skip(1).First());
            var parsedExitPoint = GetExitPoint(_fileLines.Skip(2).First());

            var mines = GetMineLocations(_fileLines.Skip(3).First());
            var moves = GetMoves(_fileLines.Skip(4).First());

            var board = new Board(parsedGridSize.x, parsedGridSize.y, parsedExitPoint, mines);
            var player = new Turtle(parsedStartingData.direction, parsedStartingData.position, board);
            
            var returned = new Game(player, moves);
            return returned;
        }

        private (int x, int y) GetGridSize(string line)
        {
            var words = line.Split(" ");
            bool parseSuccess = int.TryParse(words[2], out int width);
            if (!parseSuccess) throw new ArgumentException("Unable to find width");
            parseSuccess = int.TryParse(words[4], out int height);
            if (!parseSuccess) throw new ArgumentException("Unable to find height");
            return (width, height);
        }

        private Position GetExitPoint(string line)
        {
            var words = line.Split(" ");
            bool parseSuccess = int.TryParse(words[4], out var x);
            if (!parseSuccess) throw new ArgumentException("Unable to find exit X coords");
            parseSuccess = int.TryParse(words[8], out var y);
            if (!parseSuccess) throw new ArgumentException("Unable to find exit Y coords");
            return new Position(x, y);
        }

        private (Position position, Direction direction)  GetStartingPositionAndDirection(string line)
        {
            var words = line.Split(" ");

            bool parseSuccess = int.TryParse(words[4], out var width);
            if (!parseSuccess) throw new ArgumentException("Unable to find width");
            parseSuccess = int.TryParse(words[8], out var height);
            if (!parseSuccess) throw new ArgumentException("Unable to find height");

            parseSuccess = Enum.TryParse(words[12], out Direction parsedDirection);
            if (!parseSuccess) throw new ArgumentException("Unable to find direction");


            var parsedPosition = new Position(width, height);
            return (parsedPosition, parsedDirection);
        }

        private List<Position> GetMineLocations(string line)
        {
            var mines = new List<Position>();
            foreach (var w in Regex.Matches(line, @"\([^\d]*(\d+),(\d+)[^\d]*\)").ToList())
            {
                var word = Regex.Match(w.Value, @"\d+");       
                var newPosition = new Position(int.Parse(word.Value), int.Parse(word.NextMatch().Value));
                mines.Add(newPosition);
            }
            return mines;
        }

        private List<IMove> GetMoves(string line)
        {
            var words = line.Split(" ");
            var moves = new List<IMove>();
            foreach (var w in words.Skip(1))
            {
                if (w == MoveCommand)
                {
                    moves.Add(new StepForward());
                }
                if (w == RotateCommand)
                {
                    moves.Add(new RotateRight());
                }
            }
            return moves;
        }
    }
}
