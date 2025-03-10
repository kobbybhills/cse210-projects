using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your score? ");
        string score = Console.ReadLine();
        int numericScore = int.Parse(score);
        
        if (numericScore >= 90)
        {
            Console.WriteLine("You got an A!");
        }
        else if (numericScore >= 80)
        {
            Console.WriteLine("You got a B!");
        }
        else if (numericScore >= 70)
        {
            Console.WriteLine("You got a C!");
        }
        else if (numericScore >= 60)
        {
            Console.WriteLine("You got a D!");
        }
        else
        {
            Console.WriteLine("You got an F!");
        }
        
    }
}