namespace BlackJack{
    class GameTable{
        private Player[] players;
        private Banker banker;
        private Deck deck;
        
        public GameTable(){  // Init
            //players = new Player[1];
            banker = new Banker();
            banker.Name = "庄家";
            deck = new Deck();
        }
       
        //Send a Card to player
        public Card dealOneCardToPlayer(int i){
            Card card = deck.dealCard();
            players[i].getCard(card);
            return card;
        }
        
        //Get player point
        public int returnPlayerTotalPoint(int i){
           return players[i].getTotalPoint();
        }

        public bool playerDouble(int idx) {
            return players[idx].Double();
        }

        public void Restart() {
            deck = new Deck();
            foreach (Player p in players) {
                p.Hand.Clear();
            }
        }
        //-------------------------banker-----------------------------
        // Send a Card to Banker
        public Card dealOneCardToBanker(){
            Card card = deck.dealCard();
            banker.getCard(card);
            return card;
        }
        
        // Determine Boss if continue Get Card
        public bool isBankerContinue(){
            return banker.IsContinue();
        }
        
        // Get Boss Point
        public int returnDealerTotalCount(){
            return banker.getTotalPoint();
        }

        // Get Card Number in player
        public int GetPlayerCardNumbers(int No){
            return players[No].returnTotalCardNumInHand();
        }

        // Get Card Number in banker
        public int GetBankerCardNumbers(){
            return banker.returnTotalCardNumInHand();
        }

        // Determine the point of player if out 21 
        public bool IsPointOut(int playerNo){
            return players[playerNo].getTotalPoint() > 21;
        }

        //Determine the point of Banker if out 21 
        public bool IsBankerOut(){
            return banker.getTotalPoint() > 21;
        }

        //Get All Kinds of Attribute     
        internal Player[] Players{
            get{return players;}
            set{players = value;}
        }
        internal Banker Banker{
            get{return banker;}
            set{banker = value;}
        }
        internal Deck Deck{
            get{return deck;}
            set{deck = value;}
        }
    }
}