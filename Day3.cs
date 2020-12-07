using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2020_c_
{
    struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int xVal, int yVal)
        {
            x = xVal;
            y = yVal;
        }

        public Coordinate Add(Coordinate other) => new Coordinate(x + other.x, y + other.y);
    }

    class Day3
    {
        private static string[] puzzleInput = {
            "...#..............#.#....#..#..",
            "...#..#..#..............#..#...",
            "....#.#.......#............#...",
            "..##.....##.........#........##",
            "...#...........#...##.#...#.##.",
            "..#.#...#....#.....#........#..",
            "....##.###.....#..#.......#....",
            ".#..##...#.....#......#..#.....",
            "............##.#...#.#.....#.#.",
            "..........#....#....#.#...#...#",
            "..##....#.#.#......#.........#.",
            "#.#.........#..............##..",
            "....##.##......................",
            "....##..#...........#..........",
            "..#..#.#........##....#......#.",
            "..............#..#....#.....#..",
            ".............#...#.....#...#...",
            ".#...........#..........#...#..",
            ".#......#.......#......#.......",
            "#..#.............#..#....##.###",
            "........#.#...........##.#...#.",
            "......#..#.....##......#.......",
            ".....#.....#....#..............",
            "#...##.#......#......#...#.....",
            "...........................#...",
            "...#....................#.....#",
            "..#.....#...#.....##.....#.....",
            "....................#......#..#",
            ".......#.....##......##....#...",
            "#........##...#.....##..#...#..",
            "........#..#.#......#..###..#.#",
            "##.....#.............#.#....#..",
            "..#.................#....######",
            ".#.#..#.....#.#..........#.#...",
            ".........#....#...#............",
            "........#..#.....#.............",
            "............#.#.............##.",
            "...#....#..#......#............",
            ".##....#.....#...#.#...........",
            "..#..............#...........##",
            ".....#.#.##...#................",
            "..........#..#.#..........##..#",
            "..#....#...#...#.....######....",
            "....#.#..#........#....#.###...",
            ".......................#.......",
            "..#.....#.##................#..",
            ".....#......#..#.....#........#",
            ".#...###.......#.#.........#..#",
            "............#..................",
            "..#.........##.........##......",
            "#...........#.#.......###.#....",
            ".#...#.....#.........###.....#.",
            ".#............#........#..#....",
            "...##.#......##................",
            "........#...#...#...#..........",
            ".......#.##......##.#..........",
            "....##.......#..#....#....#....",
            "......#.........###........#...",
            "#....#....####....##......#....",
            "......................#....#.#.",
            "...#.#.#....#.#...#...#......#.",
            "......#.....##.#...........###.",
            "#........#.........##......#.#.",
            "....##.....#.....#..#..........",
            "......#...#...#.........#...##.",
            "..#........#..................#",
            ".........#..##.#..#..#...#.#..#",
            ".....#.....#...#.....###.....##",
            ".............#....#...#........",
            "..........#.#.#...#..#...#....#",
            "#...............##.......#.....",
            "#...#.............#..#...#....#",
            "..#...#...##...##...#..#.......",
            "..#..#........#.#...........#..",
            ".....#.....#..................#",
            "....#....##....###..###...##...",
            "..#......###.........##....#.##",
            ".......#.##...#.......#..#.....",
            "...#.#.#.#.....##..#..#........",
            "................##....#.#......",
            "..#...#...#...#.....##.#...#..#",
            "..#..#.....#..##....#....#.....",
            ".###...#......#........#.....##",
            "##......#..#........#..........",
            "....#...#..#....##..#......####",
            ".#.....##....#..........#......",
            ".#...#....#.........#...#....#.",
            ".....#..#.#..#......#..##....#.",
            "...#.##...#...#........#......#",
            ".#..#...#.#..#.........#...#...",
            "#....#......##.....#.......#...",
            "..##............##..#.#.#...#..",
            "##.......#.......##............",
            "#......#.##........#...#...#...",
            ".#.#.......##.........#..#.#...",
            ".............##.#........#.....",
            ".#..#...###...#..#.............",
            ".....#...#..#....#.......#.....",
            "#.#.........#.#.#...#...#.#....",
            ".....#.......#.##.##...#....#..",
            ".#.##..#.....#...#.#.#.#.#..#..",
            "..........#...................#",
            ".....#.#.#...##.........#..#..#",
            ".#..#....##......#...#.........",
            ".##......#......#...#........#.",
            ".....##.#......#............#.#",
            ".#.....##..#...........##......",
            ".....#......#.......##....#....",
            "..#..##..........#.#..........#",
            "#.#.......##..#..##.#....#.....",
            ".......#..#.#.......##......#.#",
            "....#...##...#..............#..",
            ".....#.........#......#...##...",
            "#.........#........##..#.....#.",
            ".#.#..#.....##.......#......#..",
            "........#..#....#.....###..#...",
            "#.#..#.#..........#............",
            "..#......##..#....#.........#..",
            "#..............................",
            ".......#............#..#..#.#..",
            ".#.....#.#....#..#.##.#........",
            ".......#.###.#........##.#..#..",
            "..............#....#.....##.#..",
            "#..............#....#.###......",
            ".#..#..#...###............#...#",
            ".#.##...#....#..#...#...#......",
            "......##..#..#......#..#....#..",
            ".........#.......##............",
            "...........##...#..#....####...",
            ".#..................#..........",
            "#...#..#..................#....",
            "..............#.....##.....#...",
            "..#.#..#...##..#.....#.....#..#",
            "....#....#.#.........#.....#...",
            ".#.......#...#....#...#.#..#..#",
            "#.........##.....##.......#...#",
            "#..#............#....#........#",
            "..........##...#......#....#...",
            ".......#..##...............#...",
            "#............#.#.#.....#.......",
            ".#........##...#...............",
            "..##....#.....#..#.##.#......#.",
            ".#...#.............#...#.....#.",
            "...##....#.......#......#.#..#.",
            "#......................#..#.##.",
            "...#..........#..#.........#...",
            "..#......#.......#.#....#......",
            "....#............#...#......#..",
            ".....#..#..##...#...#.........#",
            ".....#......#....#....#........",
            ".............#..#..........#...",
            "....#..............#.....#.#...",
            "....#.................#.#...#.#",
            ".........#.#...........###.#.##",
            "#...........#..##.#....#.##.#..",
            "#.#.....#......................",
            "##.#.........#....##.#.#..#.#..",
            "#..........#.#.#.#.#..#..##..#.",
            "..#...#..###.........#......#..",
            ".....#......#..#.#............#",
            "...........#...#.#.#.###....#..",
            "#....#..#.......##.#.......##..",
            "..............#.....##.#.......",
            ".#.....#.#..#.........#.#.#..#.",
            "..#..#..#..#................#..",
            "...........#..#.#...#.........#",
            ".#..#..#...#........#...#.#..#.",
            "...#.#..#......#..#............",
            "........#......##.....#....#...",
            "#...#......##.#.#..............",
            ".#........................#....",
            "#.#.....#.##.....#..#.#........",
            "#..........##.#.......#....#..#",
            "#...#..#..#.....#....#....#....",
            "#...........#..#.#....##.##....",
            "##......#..#........#.......##.",
            "#........#..#...#..........#...",
            "...#...#......##....#.#........",
            "...##..#..#.##....#...#........",
            "#.#..#....#...#........#.......",
            "..........#.......#..........#.",
            "......##...#....###...#....#...",
            "........#..#.....#......#......",
            "....#.........##...#..##......#",
            "....#...........#.#..#.#.#.#..#",
            "..#......#..#......#........#.#",
            "#..#....#.....#.............#..",
            "............................#..",
            "#...#.#.....#...#....#....#....",
            "........#...#...#...#...#......",
            ".###........#....#.##.....##.#.",
            ".........#.....#..........#....",
            ".#.........#....##.#.....#.....",
            "#..#....................##.#...",
            "..##.#.............#....#.#....",
            "..#.#........#............##.#.",
            "#........#...##.....#...#.....#",
            ".........#.#..........#....#..#",
            "...###.#..#.#......#.#.....#...",
            "......#.....#..#...#........#..",
            ".......#...#.....#....#....#..#",
            ".#.#........#......##.......#..",
            "#.................###..........",
            "#........#.#..#....#..#........",
            "..##....#.#...##...#...##....#.",
            "...#.#......##...#.....#..#....",
            "#..#........#...###....#.......",
            "##.#....#..#.#..........#......",
            "....#...###...#.....#........#.",
            "..#.#........#....##.#.........",
            "......##.##.................##.",
            ".#....##...#.#..#.#............",
            ".#...###........#......#.......",
            "##..#.#......#..#..#...#.......",
            ".......##..#....#........#....#",
            "......#..........#.............",
            "....##..##..#......#.#.........",
            ".....#....................##...",
            "...###.....#.....#...#.#.##.#..",
            "....#.#..#.......#..#......##..",
            ".......#.#..#.##.#...#......#..",
            "...#.#....#.#...#..##...#...#..",
            "#.##...#....#..#.............#.",
            "...#...#...#.......#..........#",
            ".#..#.............#..##.#......",
            "....#.......#..............#.#.",
            "..................#..#.....##.#",
            ".#...#..#......#..........#...#",
            "..#.#.....#..#....#....#####.#.",
            ".......###.......#....#....#...",
            "......#.#........#...#.........",
            "......#..#.#.#....#.#.#....##..",
            ".#...#.#...##.#......#.........",
            "#....#..##....#.#.......#....#.",
            "..##.#.....#.....#.........#...",
            "......#......#....#....#.....#.",
            "...##.....#....#......#......#.",
            "......#......##............#.#.",
            ".##.#.......#....#...#....#....",
            "....#..#..#...##.......#..#....",
            "....#....#...#.#........#..#...",
            "....#.....#..........#..#......",
            "....#....#...#.....#..##.....#.",
            "##...#..##......#....##..#..#..",
            ".....##.##..............##.....",
            "#.#....#.##..#....#...##.......",
            "..#.....##.....#.....######...#",
            "...#.....#.#.#......#......##.#",
            "...........##.............#....",
            "...##......#..#......#...#.....",
            "....#.##......#..#....#.#..#...",
            ".#..#....#...#..#.....##.......",
            ".....#..#.................#..#.",
            "................#..#...#......#",
            "...##....#.....#..#....##......",
            "....##...............##...#....",
            "......#..........#..##.........",
            ".......###.......#.........#..#",
            "......................#....#.#.",
            "#.#.....#...##............#....",
            "........#......##......#.....#.",
            "...#....#....#.#..##.#..#.#.#..",
            "..#.#....#.##...#..#.....#.#...",
            "............#....#..#.......#..",
            "#...#...#.#......#...##.....#.#",
            "......#....#....#.......#......",
            "....#.......#..........#....#..",
            "........#####........#....#....",
            "......#....##..............#.#.",
            "....#....#.......#.......#.....",
            ".##.#....##....#...............",
            "#.....##........#..#.#...#.#...",
            "...#......##....#..............",
            ".#.....#.....#.......##....##..",
            "#....#..........#.#..#.........",
            "......##..........##.......#...",
            ".##......##.....#.#....#......#",
            "....#......................#...",
            ".#...........###........#...#..",
            "#.#..#..#..#...##.#....#.#..#..",
            "...##...........#.#..........#.",
            "......#.#..#....#....#.........",
            "....#....#.#......#.........##.",
            ".#..#...#...##....#...#......#.",
            "#.#......#...#.#.#...........#.",
            "##.....#..........##....##..##.",
            "...#.#.....#..##........#......",
            "..#........##........#..#......",
            ".......#...............##..#...",
            ".......#.#....#..###...........",
            ".............#........#...#....",
            "#.................#......#..#..",
            "...#....#..#..............#...#",
            ".............#....##....#..##..",
            "#........#..........##...##...#",
            "............#....#.....#.#....#",
            ".....#..............##..#...#..",
            "..#....#......###....#.#...##..",
            "....##......#.....#....#.......",
            ".....#...............#.....#...",
            ".#.....#.....#..............#..",
            "#................#..#..........",
            ".##....#....#.....#............",
            "#.####...#..#..#....#..........",
            "..##........##.....##......#..#",
            "......#.....#...##.........##..",
            "....##..#.....#.#.........#...#",
            ".....##..#....#....#.#...#..#..",
            "...#............#...........#..",
            ".......#.#..#.#.#..#........#.#",
            "....#.#........#.#.#..#...#...#",
            "..#....#....#..#......#........",
            ".#...........................#.",
            ".#..#....####........##......#.",
            ".#.....#..#.#.................#",
            ".#..#...........#...#....#...#.",
            "......##..#........#..#....#...",
            "..#.............#....#........#",
            "#.#..........#.##.......#.#..#.",
            "..#....#...#...............#...",
            "..............#..........#..#..",
            "..#.....#.#.....#...#...#..#...",
            ".........#...###.#...#........#",
        };

        public static char TreeToken = '#';

        public static Coordinate MovingPattern = new Coordinate(3, 1);

        // Use mod to create an infinite repetition horizontally
        private static bool IsTree(Coordinate coordinate) => puzzleInput[coordinate.y][coordinate.x % puzzleInput[0].Length] == TreeToken;

        private static IEnumerable<Coordinate> GenerateCoordinates(string[] input)
        {
            var current = new Coordinate(0, 0);
            while (current.y < (puzzleInput.Length - 1))
            {
                current = current.Add(MovingPattern);
                yield return current;
            }
        }

        public static void Run()
        {
            Console.WriteLine($"Day 3 Part 1 answer: {GenerateCoordinates(puzzleInput).Count(IsTree)}");
        }
    }
}