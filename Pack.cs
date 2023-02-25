namespace CMP1903M_A01_2223
{
// Class representing a pack of cards
class Pack
{
List<Card> pack; // List of cards in the pack
    
    // Constructor that creates a new pack of cards
    public Pack()
    {
        pack = new List<Card>();
        for (int suit = 1; suit <= 4; suit++)
        {
            for (int value = 1; value <= 13; value++)
            {
                pack.Add(new Card { Suit = suit, Value = value });
            }
        }
    }

    // Method that shuffles the pack of cards
    public bool ShuffleCardPack(int typeOfShuffle)
    {
        // Shuffle the pack based on the type of shuffle
        switch (typeOfShuffle)
        {
            case 1:
                FisherYatesShuffle();
                break;
            case 2:
                RiffleShuffle();
                break;
            case 3:
                // No shuffle needed
                break;
            default:
                throw new ArgumentException("Invalid typeOfShuffle value");
        }
        return true; // Return true to indicate success
    }

    // Method that deals one card from the top of the pack
    public Card DealCard()
    {
        // Deal one card from the top of the pack and remove it
        if (pack.Count == 0)
        {
            throw new InvalidOperationException("pack is empty");
        }
        Card card = pack[0];
        pack.RemoveAt(0);
        return card;
    }

    // Method that deals a specified number of cards from the top of the pack
    public List<Card> DealCard(int amount)
    {
        // Deal the specified number of cards from the top of the pack and remove them
        if (amount > pack.Count)
        {
            throw new InvalidOperationException("pack doesn't have enough cards");
        }
        List<Card> cards = pack.GetRange(0, amount);
        pack.RemoveRange(0, amount);
        return cards;
    }

    // Private method that implements the Fisher-Yates shuffle algorithm
    private void FisherYatesShuffle()
    {
        int n = pack.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = new Random().Next(i + 1);
            Card temp = pack[i];
            pack[i] = pack[j];
            pack[j] = temp;
        }
    }

    // Private method that implements the riffle shuffle algorithm
    private void RiffleShuffle()
    {
        int n = pack.Count;
        int cut = new Random().Next(1, n - 1);
        List<Card> left = pack.GetRange(0, cut);
        List<Card> right = pack.GetRange(cut, n - cut);
        pack.Clear();
        while (left.Count > 0 && right.Count > 0)
        {
            if (new Random().Next(2) == 0)
            {
                pack.Add(left[0]);
                left.RemoveAt(0);
            }
            else
            {
                pack.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        pack.AddRange(left);
        pack.AddRange(right);
    }

}
}
