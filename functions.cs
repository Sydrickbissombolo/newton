using System;

class Program {
    static void Main(string[] args) {
        // Call the DisplayWelcome function
        DisplayWelcome();

        // Call the PromptUserName function
        string name = PromptUserName();

        // Call the PromptUserNumber function
        int number = PromptUserNumber();

        // Call the SquareNumber function
        int squared = SquareNumber(number);

        // Call the DisplayResult function
        DisplayResult(name, squared);
    }

    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName() {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    static int PromptUserNumber() {
        Console.Write("What is your favorite number? ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number) {
        return number * number;
    }

    static void DisplayResult(string name, int squared) {
        Console.WriteLine("{0}, your favorite number squared is {1}.", name, squared);
    }
}
