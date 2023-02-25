using System;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new card pack
            Pack pack = new Pack();

            // Shuffle the card pack using Fisher-Yates shuffle
            pack.ShuffleCardPack(1);

            // Deal and display one card
            Card card = pack.DealCard();
            Console.WriteLine("Dealt card: " + card.ToString());

            // Deal and display a hand of five cards
            var hand = pack.DealCard(5);
            Console.WriteLine("Dealt hand of " + hand.Count + " cards:");
            foreach (var c in hand)
            {
                Console.WriteLine(c.ToString());
            }

            // Shuffle the card pack using Riffle shuffle
            pack.ShuffleCardPack(2);

            // Deal and display one more card
            Card anotherCard = pack.DealCard();
            Console.WriteLine("Dealt another card: " + anotherCard.ToString());

            Console.ReadLine();
        }
    }
}

