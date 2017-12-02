namespace BlackJack{
    class Player :Person{
        private Bet bet;    //player's wager
        private int money;  //player's capital

        public Player(){
            Bet = new Bet();
            Money = 1000;
        }

        public bool Double() {
            bet.betNum *= 2;
            if (bet.betNum <= money) return true;
            bet.betNum /= 2;
            return false;
        }

        public int Money{
            get{return money;}
            set{money = value;}
        }

        public Bet Bet{
            get{return bet;}
            set{bet = value;}
        }
    }
}