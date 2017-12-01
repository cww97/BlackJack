using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    class Bet{
        private int betNumber;  //the number of a player's bet
        public Bet(){
            betNumber = 10;
        }
        public Bet(int betNumber){
            this.betNumber = betNumber;
        }

        public int betNum{
            set{betNumber = value;}
            get{return betNumber;}
        }

        public void addBetMoney(int betnum){  //Add Bet
            betNumber += betnum;
        }
        
    }
}