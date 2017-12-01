using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    class Player :Person{
        private Bet bet;    //player's wager
        private int money;  //player's capital
        public Player(){
            Bet = new Bet();
            Money = 1000;
        }

        public int Money{
            get{return money;}
            set{money = value;}
        }

        internal Bet Bet{
            get{return bet;}
            set{bet = value;}
        }
    }
}