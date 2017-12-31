using System;


namespace BlackJack{
    class GameTable{
        private Player[] players;
        private Banker banker;
        private Deck deck;
        private int AllBet;
        
        public GameTable(){  // Init
            //players = new Player[1];
            banker = new Banker();
            banker.Name = "庄家";
            deck = new Deck();
            AllBet = 0;
        }
       
        // Send a Card to player
        public Card DealOneCardToPlayer(int i){
            Card card = deck.dealCard();
            players[i].GetCard(card);
            return card;
        }
        
        // Get player point
        public int PlayerTotalPoint(int i){
           return players[i].GetTotalPoint();
        }

        public void Restart() {
            deck = new Deck();
            foreach (Player p in players) {
                p.Hand.Clear();
            }
            AllBet = 0;
        }

        public int GetPlayerMoney(int idx){
            return players[idx].Money;
        }
        
        public int GetPlayerBet(int idx){
            return players[idx].Bet.betNum;
        }

        public void PlayerBet(int idx, int bet){ // 保证兜里钱够
            players[idx].Bet.betNum = bet;
            AllBet += bet;
        }

        public bool AddBet(int p, int v)
        {
            AllBet += v;
            return players[p].AddBet(v);
        }

        public void PlayerWin(int idx, int cnt){
            Console.WriteLine("AllBet = " + AllBet);
            players[idx].Win(AllBet/cnt);
        }
        
        public void PlayerLose(int idx){
            players[idx].Lose();
        }

        public int SortPlayers(int playerCnt)
        {
            for (int i = 0; i < playerCnt - 1; i++)
            {
                for (int j = i + 1; j < playerCnt; j++)
                {
                    if (players[i].GetTotalPoint() < players[j].GetTotalPoint())
                    {
                        Player tmp = players[i];
                        players[i] = players[j];
                        players[j] = tmp;
                    }
                }
            }
            
            return players[0].GetTotalPoint();
        }

        public int GetWinCnt(int playerCnt){
            int ans = 0;
            for (int i = 0; i < playerCnt; i++){
                if (players[i].GetTotalPoint() == players[0].GetTotalPoint()) ans++;
            }
            return ans;
        }

        //-------------------------banker-----------------------------
        // Send a Card to Banker
        public Card DealOneCardToBanker(){
            Card card = deck.dealCard();
            banker.GetCard(card);
            return card;
        }
        
        // Determine Boss if continue Get Card
        public bool BankerContinue(){
            return banker.IsContinue();
        }
        
        // Get Boss Point
        public int DealerTotalCount(){
            return banker.GetTotalPoint();
        }

        // Determine the point of player if out BREAK_POINT 
        public bool IsPointOut(int playerNo){
            return players[playerNo].GetTotalPoint() == -1;
        }

        //Determine the point of Banker if out BREAK_POINT 
        public bool IsBankerOut()
        {
            return banker.GetTotalPoint() == -1;
        }
        
        //Show Hand Card
        public string ShowBankerHandCard(){
            return banker.GetHandCard();
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