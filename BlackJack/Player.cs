using System.Collections.Generic;
using System.Xml.Schema;

namespace BlackJack{
    class Player :Person{
        private Bet bet;    //player's wager
        private int money;  //player's capital

        public Player(){
            Bet = new Bet();
            Money = 1000;
        }

        public bool AddBet(int v) {
            if (bet.betNum + v > money) return false;
            bet.betNum += v;
            return true;
        }

        public void Win(int v){
            money += v;
            bet = new Bet();
        }

        public void Lose(){
            money -= bet.betNum;
            bet = new Bet();
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