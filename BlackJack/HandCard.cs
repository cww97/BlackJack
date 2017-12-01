using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    //a player has a hand of cards
    class HandCard{
        private List<Card> cardList;
        public HandCard(){
            cardList = new List<Card>();
        }
        
        internal List<Card> CardList{
            get{return cardList;}
            set{cardList = value;}
        }

       //Compute Hand Card Point
        public int countTotalPoint(){
            int totalPointCount = 0;
            foreach (Card card in cardList){
                int value = card.GetCardValue();
                totalPointCount += value;
            }
            
            foreach (Card card in cardList){
                //special card "A",deal with it
                if (card.GetCardValue() == 1){
                    if (totalPointCount + 10 <= 21) totalPointCount += 10;
                }
            }
            return totalPointCount;
        }

        //Add Card to Bank
        public void addBankedCard(Card card){
            cardList.Add(card);
        }

        //Get Card Number
        public int getCardNum(){
            return CardList.Count;
        }

        //Determine if BlackJack
        public bool checkBlackJack(){
            return getCardNum() == 2 && countTotalPoint() == 21;
        }
    }
}