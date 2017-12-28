namespace BlackJack{
    class Bet{  // 在某一局下的赌注
        private int betNumber;  // the number of a player's bet

        public Bet(){
            betNumber = 10;
        }

        public int betNum{
            set{betNumber = value;}
            get{return betNumber;}
        }

        public void Add(int betnum){  //Add Bet
            betNumber += betnum;
        }
    }
}