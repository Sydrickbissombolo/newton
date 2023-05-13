using System;
using System.Collections.Generic;
using System.IO;

namespace JournalingProgram {
	class Program {
		static void Main(string[] args) {
			Journal journal = new Journal();
			bool running = true;

			while (running) {
				Console.WriteLine("\nWhat would you like to do?");
				Console.WriteLine("1. Write a new entry");
				Console.WriteLine("2. Display the journal");
				Console.WriteLine("3. Save the journal to a file");
				Console.WriteLine("4. Load the journal from a file");
				Console.WriteLine("5. Quit");

				int choice = GetIntInput(1, 5);

				switch (choice) {
					case 1:
						journal.NewEntry();
						break;
					case 2:
						journal.Display();
						break;
					case 3:
						Console.Write("Enter a filename to save the journal to: ");
						string filename = Console.ReadLine();
						journal.Save(filename);
						break;
					case 4:
						Console.Write("Enter the filename to load the journal from: ");
						filename = Console.ReadLine();
						journal.Load(filename);
						break;
					case 5:
						running = false;
						break;
				}
			}
		}

		static int GetIntInput(int min, int max) {
			while (true) {
				Console.Write("Enter a number between {min} and {max}: ");
				if (int.TryParse(Console.ReadLine(), out int result)) {
					if (result >= min && result <= max) {
						return result;
					}
				}
				Console.WriteLine("Invalid input. Please try again.");
			}
		}
	}

	class Journal {
		private List < Entry > entries;

		public Journal() {
			entries = new List < Entry > ();
		}

		public void NewEntry() {
				Random random = new Random();
				string[] prompts = {
					"Who was the most interesting person I interacted with today?",
					"What was the best part of my day?",
					"How did I see the hand of the Lord in my life today?",
					"What was the strongest emotion I felt today?",
					"If I had one thing I could do over today, what would it be?",
					"What did I learn today?",
					"What am I grateful for today?",
					"What is something that challenged me today?",
					"What are my goals for tomorrow?"
				};
				string prompt = prompts[random.Next(prompts.Length)];
				Console.WriteLine(prompt);

				Console.Write("Type your response: ");
				string response = Console.ReadLine();

				Console.Write("Type your mood for the day (e.g. Joyful, sad, anxious): ");
				string mood = Console.ReadLine();

				Entry entry = new Entry(prompt, response, mood);
				entries.Add(entry);



				public void Display() {
					if (entries.Count == 0); {
						Console.WriteLine("No entries to display.");
						return;
					}

					entries.Sort((x, y) => DateTime.Compare(y.Date, x.Date)); // Sort entries by date in descending order
					Console.WriteLine("\nJournal Entries:\n");

					foreach(Entry entry in entries); {
						Console.WriteLine("{entry.Date} - {entry.Prompt} ({entry.WordCount} words)");
						Console.WriteLine("Mood: {entry.Mood}");
						Console.WriteLine(entry.Response);
						Console.WriteLine();
					}
				}

				public void Save(string filename) {
					using(StreamWriter writer = new StreamWriter(filename)) {
						foreach(Entry entry in entries) {
							writer.WriteLine("{entry.Date} - {entry.Prompt} ({entry.WordCount} words)");
						}
					}
				}
