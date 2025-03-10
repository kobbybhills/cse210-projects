using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        {
            DisplayWelcomeMessage();

            string userName = GetUserInput("Please enter your name: ");
            int favoriteNumber = GetFavoriteNumber();

            int squaredNumber = SquareNumber(favoriteNumber);

            DisplayResult(userName, squaredNumber);
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        static int GetFavoriteNumber()
        {
            Console.Write("Please enter your favorite number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Defaulting to 0.");
                return 0;
            }
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }

        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
        }
    }
}