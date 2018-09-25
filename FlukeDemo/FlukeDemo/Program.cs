using System;



namespace FlukeDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var reader = new TextFileReader("../../../input.txt");
            var game = reader.LoadFileGame();
            game.Play();
        }
    }
}