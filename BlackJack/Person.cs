using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    //class Player's and class Banker's superclass
    //this class contains basic operation
    class Person{
        private HandCard hand;
        private string name;
        public Person(){
            hand = new HandCard();
        }

        internal string Name{
            get{return name;}
            set{name = value;}
        }

        internal HandCard Hand{
            get{return hand;}
            set{hand = value;}
        }

        //Call in Send Card
        public void getCard(Card card){
            Hand.addBankedCard(card);
        }

        //Get Point
        public int getTotalPoint(){
            return Hand.countTotalPoint();
        }

        //Get Card Number in Hand
        public int returnTotalCardNumInHand(){
            return Hand.getCardNum();
        }

        //Determine if BlackJack
        public bool isBlackJack(){
            return Hand.checkBlackJack();
        }
    }
}