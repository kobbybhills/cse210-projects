using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project,it's focused on getting your name and then returnin your name and a specified order,Thank you!.");
        

        
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();


        Console.Write("What is  your last name? ");
        string lastName = Console.ReadLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}