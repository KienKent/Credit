using Credit.Database.Repositories;

namespace Credit.Database
{
    public abstract class RepositoryList
    {
        #region player data
        public abstract PlayerRepository PlayerRepository { get; }
        public abstract DeckRepository DeckRepository { get; }
        public abstract DeckCardRepository DeckCardRepository { get; }
        #endregion
    }
}
