using System;
using System.Collections.Generic;

namespace CSharpExamples
{
    public class SnakeGame
    {
        private const char wallChar = '#';
        private const char snakeChar = '*';

        private readonly int width;
        private readonly int height;

        private int snakeLength = 2;
        private List<int> xPositions = new List<int>();
        private List<int> yPositions = new List<int>();

        private decimal gameSpeed = 100.0m;

        private SnakeFood food;

        public bool IsGoing { get; private set; } = false;

        public SnakeGame(int width, int height)
        {
            this.width = width;
            this.height = height;

            this.food = new SnakeFood(width, height);

            xPositions.Add(width / 2);
            yPositions.Add(height / 2);
        }

        public void Start()
        {
            BuildWall();
            food.Display();
            DisplaySnake();

            IsGoing = true;

            ConsoleKey command = Console.ReadKey(true).Key;

            do
            {
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        xPositions[0] -= 1;
                        break;
                    case ConsoleKey.UpArrow:
                        yPositions[0] -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        xPositions[0] += 1;
                        break;
                    case ConsoleKey.DownArrow:
                        yPositions[0] += 1;
                        break;
                }

                DisplaySnake();

                if (DidHitWall())
                {
                    IsGoing = false;
                    Console.SetCursorPosition(0, height);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The snake hit the wall and died");
                }

                if (DidEatFood())
                {
                    food.ChangePosition();
                    food.Display();
                    snakeLength += 1;
                    gameSpeed *= .925m;
                }

                Console.ForegroundColor = ConsoleColor.Black;

                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey(true).Key;
                }

            } while (IsGoing);
        }

        private void BuildWall()
        {
            for (int i = 0; i < height; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, i);
                Console.Write(wallChar);

                Console.SetCursorPosition(width - 1, i);
                Console.Write(wallChar);
            }

            for (int i = 0; i < width; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 0);
                Console.Write(wallChar);

                Console.SetCursorPosition(i, height - 1);
                Console.Write(wallChar);
            }
        }

        private void DisplaySnake()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (xPositions.Count < snakeLength)
            {
                xPositions.Add(xPositions[xPositions.Count - 1]);
            }

            if (yPositions.Count < snakeLength)
            {
                yPositions.Add(yPositions[yPositions.Count - 1]);
            }

            Console.SetCursorPosition(xPositions[0], yPositions[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(snakeChar);

            for (int i = 0; i < snakeLength; i++)
            {
                Console.SetCursorPosition(xPositions[i], yPositions[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(snakeChar);
            }

            Console.SetCursorPosition(xPositions[xPositions.Count - 1], yPositions[yPositions.Count - 1]);
            Console.Write(" ");

            for (int i = snakeLength - 1; i > 0; i--)
            {
                xPositions[i] = xPositions[i - 1];
                yPositions[i] = yPositions[i - 1];
            }
        }

        private bool DidEatFood()
        {
            if (xPositions[0] == food.XPosition && yPositions[0] == food.YPosition)
            {
                return true;
            }

            return false;
        }

        private bool DidHitWall()
        {
            if (xPositions[0] <= 0 || xPositions[0] >= width - 1 || yPositions[0] == 0 || yPositions[0] == height - 1)
            {
                return true;
            }

            return false;
        }
    }

    class SnakeFood
    {
        private const char foodChar = '@';
        const int wallBuffer = 2;

        private readonly int width;
        private readonly int height;

        private readonly Random random;

        internal int XPosition { get; private set; } = 2;
        internal int YPosition { get; private set; } = 2;

        internal SnakeFood(int width, int height)
        {
            this.width = width;
            this.height = height;

            random = new Random();

            ChangePosition();
        }

        internal void ChangePosition()
        {
            XPosition = random.Next(0 + wallBuffer, width - 1 - wallBuffer);
            YPosition = random.Next(0 + wallBuffer, height - 1 - wallBuffer);
        }

        internal void Display()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(foodChar);
        }
    }
}
