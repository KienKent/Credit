using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit.Library
{
    public class Player
    {
        public EndPoint EndPoint { get; set; }
        public int PlayerID { get; private set; }
        public IPAddress LastConnectedIPAddress { get; set; }
        public string Account { get; private set; }
        public string Nickname { get; private set; }
        private Dictionary<int, Deck> deckDictionary = new Dictionary<int, Deck>();
        public IEnumerable<Deck> Decks { get { return deckDictionary.Values.ToArray(); } }

        public PlayerEventManager EventManager { get; private set; }
        public PlayerOperationManager OperationManager { get; private set; }
        public PlayerResponseManager ResponseManager { get; private set; }


        public Player(int playerID, IPAddress lastConnectedIPAddress, string account, string nickname)
        {
            PlayerID = playerID;
            LastConnectedIPAddress = lastConnectedIPAddress;
            Account = account;
            Nickname = nickname;

            EventManager = new PlayerEventManager(this);
            OperationManager = new PlayerOperationManager(this);
            ResponseManager = new PlayerResponseManager(this);
        }
        public Player(int playerID, string nickname)
        {
            PlayerID = playerID;
            Nickname = nickname;
        }

    }
}
