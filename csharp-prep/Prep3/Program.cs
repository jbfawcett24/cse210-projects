using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Random randNum = new Random();
        int intGuess;
        bool game = true;
        string guess;
        do {
            int secretNum = randNum.Next(1, 100);
            //Console.WriteLine($"the secret number is: {secretNum}");
            int i = 1;
            do {
                Console.Write($"Guess {i}: ");
                guess = Console.ReadLine();
                intGuess = int.Parse(guess);
                if(intGuess == secretNum){
                    Console.WriteLine($"You guessed the number in {i} guesses");
                } else if (intGuess < secretNum) {
                    Console.WriteLine("Higher");
                    i++;
                } else if (intGuess > secretNum) {
                    Console.WriteLine("Lower");
                    i++;
                } 
            } while (intGuess != secretNum);
            Console.Write("Would you like to play again? (Y/N): ");
            string playAgain = Console.ReadLine();
            if(playAgain == "N") {
                game = false;
            }
        } while (game == true);
    }
}