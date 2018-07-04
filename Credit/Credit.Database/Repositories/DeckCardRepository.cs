using Credit.Library;
using System.Collections.Generic;

namespace Credit.Database.Repositories
{
    public abstract class DeckCardRepository
    {
        public abstract bool Create(int deckID, int cardID);
        public abstract bool Delete(int deckID, int cardID);
        public abstract List<Card> ListOfDeck(int deckID);
    }
}
