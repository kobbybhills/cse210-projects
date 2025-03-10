using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Please guess a Higher number");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Please guess a Lower number");
            }
            else
            {
                Console.WriteLine("Brilliant, You guessed it!");
            }
        }
    }
}