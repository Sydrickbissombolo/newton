using System;

class Program {
    static void Main(string[] args) {
        Random random = new Random();
        string playAgain = "yes";

        while (playAgain == "yes") {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess = 0;

            while (guess != magicNumber) {
                Console.WriteLine("Guess the magic number:");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber) {
                    Console.WriteLine("Your guess is too low, please guess higher next time.");
                } else if (guess > magicNumber) {
                    Console.WriteLine("Your guess is too high, please guess lower next time.");
                } else {
                    Console.WriteLine("Congratulations, you guessed the magic number!");
                    Console.WriteLine("You took " + guessCount + " guesses.");
                }
            }

            Console.WriteLine("Do you want to play again? (yes or no)");
            playAgain = Console.ReadLine().ToLower();
        }
    }
}
