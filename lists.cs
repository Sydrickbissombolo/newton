using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<int> numbers = new List<int>();
        int input;

        do {
            Console.Write("Enter a number (0 to stop): ");
            input = int.Parse(Console.ReadLine());

            if (input != 0) {
                numbers.Add(input);
            }
        } while (input != 0);

        Console.WriteLine("Numbers entered:");
        foreach (int number in numbers) {
            Console.WriteLine(number);
        }

        // Compute sum of the numbers
        int sum = 0;
        foreach (int number in numbers) {
            sum += number;
        }
        Console.WriteLine("Sum: " + sum);

        // Compute average of the numbers
        double average = (double)sum / numbers.Count;
        Console.WriteLine("Average: " + average);

        // Find maximum number
        int max = numbers[0];
        foreach (int number in numbers) {
            if (number > max) {
                max = number;
            }
        }
        Console.WriteLine("Maximum: " + max);
    }
}
