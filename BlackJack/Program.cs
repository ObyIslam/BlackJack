using System;

namespace BlackJack
{
    internal class Program
    {
        static Random rnd = new Random();
        static int win = 0;
        static int loss = 0;
        static string space = "----------------------------------------";
        static void Main(string[] args)
        {

            while (true)
            {
                PlayBlackjack();
                Console.WriteLine(space);
                Console.Write("Do you want to play again or see your statistcs (y/s): ");
                string answer = Console.ReadLine();

                while (answer != "y" && answer != "s")
                {
                    Console.Write("Please enter y or s: ");
                    answer = Console.ReadLine();
                }
                if (answer.ToLower() == "y")//to play again
                {
                    PlayBlackjack();
                }
                else if (answer.ToLower() == "s")//to see statistics
                {
                    Console.WriteLine(space);
                    Statistics();
                    break;
                }

            }

        }

        static void PlayBlackjack()//Begins BlackJack Game
        {
            
            

            Deck deck = new Deck();

            BlackJack playerHand = new BlackJack(GenerateRandomCard());
            BlackJack dealerHand = new BlackJack(GenerateRandomCard());

            //Cards are given out to player and dealer
            Console.WriteLine(space);
            Console.WriteLine($"Player Card dealt is the {playerHand.Card}");
            Console.WriteLine($"Dealer Card dealt is the {dealerHand.Card}");

            int playerScore = playerHand.CalculateScore();
            int dealerScore = dealerHand.CalculateScore();
            //score after round 1
            Console.WriteLine(space);
            Console.WriteLine($"Your current Score is {playerScore}");
            Console.WriteLine($"Dealer's current Score is {dealerScore}");

            //stand or hit part
            while (playerScore < 21)
            {
                Console.Write("Do you want to stand or hit - s/h? ");

                string choice = Console.ReadLine().ToLower();

                if (choice == "h")
                {
                    BlackJack newCard = new BlackJack(GenerateRandomCard());
                    Console.WriteLine(space);
                    Console.WriteLine($"Player Card dealt is the {newCard.Card}");
                    playerScore = newCard.CalculateScore() + playerScore;
                    Console.WriteLine($"Your current score is {playerScore}");

                    if (playerScore > 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bust! You lose.");
                        Console.ResetColor();
                        return;
                    }
                }
                else if (choice == "s")
                {
                    break;
                }
            }

            Console.WriteLine(space);

            // Dealer's turn
            while (dealerScore < 17)
            {
                BlackJack newCard = new BlackJack(GenerateRandomCard());

                Console.WriteLine($"Card dealt to dealer is the {newCard.Card}");
                dealerScore = newCard.CalculateScore() + dealerScore;
            }

            Console.WriteLine($"Your Score is {playerScore}");
            Console.WriteLine($"Dealer's Score is {dealerScore}");

            // Determine the winner
            if (playerScore > 21 || (dealerScore <= 21 && dealerScore >= playerScore))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dealer wins.");
                Console.ResetColor();
                loss++;
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You win!");
                Console.ResetColor();
                win++;
                return;
            }
        }

        static string GenerateRandomCard()//Generates Card
        {
            Deck deck = new Deck();
            int randomNumber = rnd.Next(0, deck.Cards.Count); // Generate a random number between 1 and size of deck

            if (randomNumber >= 0 && randomNumber < deck.Cards.Count)
            {
                string randomCard = deck.Cards[randomNumber].ToString();
                return randomCard;
            }

            return null; //if the deck of cards run out
        }

        static void Statistics()
        {
            Console.WriteLine($"Your total wins are {win}");
            Console.WriteLine($"Your total losses are {loss}");
        }


    }

}

