namespace BlackJack
{
    internal class Program
    {

        static string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        static string space = "----------------------------------------";
        static void Main(string[] args)
        {

            while (true)
            {
                PlayBlackjack();
                Console.Write("Do you want to play again? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    break;
                }

            }

        }

        static void PlayBlackjack()
        {
            BlackJack playerHand = new BlackJack(GenerateRandomCard());
            BlackJack dealerHand = new BlackJack(GenerateRandomCard());

            Console.WriteLine($"Player Card dealt is the {playerHand.Card}");
            Console.WriteLine($"Dealer Card dealt is the {dealerHand.Card}");

            int playerScore = playerHand.CalculateScore();
            int dealerScore = dealerHand.CalculateScore();

            Console.WriteLine(space);
            Console.WriteLine($"Your current Score is {playerScore}");
            Console.WriteLine($"Dealer's current Score is {dealerScore}");

            //stick or twist part
            while (playerScore < 21)
            {
                Console.Write("Do you want to stick or twist - s/t? ");
                
                string choice = Console.ReadLine().ToLower();

                if (choice == "t")
                {
                    BlackJack newCard = new BlackJack(GenerateRandomCard());
                    Console.WriteLine(space);
                    Console.WriteLine($"Player Card dealt is the {newCard.Card}");
                    playerScore = newCard.CalculateScore() + playerScore;
                    Console.WriteLine($"Your current score is {playerScore}");

                    if (playerScore > 21)
                    {
                        Console.WriteLine("Bust! You lose.");
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
                Console.WriteLine("Dealer wins.");
            }
            else
            {
                Console.WriteLine("You win!");
            }
        }

        static string GenerateRandomCard()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

            Random random = new Random();
            int randomSuitIndex = random.Next(suits.Length);
            int randomRankIndex = random.Next(ranks.Length);
            string randomCard = ranks[randomRankIndex] + " of " + suits[randomSuitIndex];
            return randomCard;
        }

    }

    



}

