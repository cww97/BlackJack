using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    class HandCard{ // 手牌
        private List<Card> cardList;

        private const int BREAK_POINT = 22;
        
        public HandCard(){
            cardList = new List<Card>();
        }

        public void Clear() {
            cardList.Clear();
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
                    if (totalPointCount + 9 <= BREAK_POINT) totalPointCount += 9;
                }
            }
            return totalPointCount;
        }
        //Show Hand Card
        public String showHandCard(){
            string face = "";
            foreach (Card card in cardList){
                face += "" + card.GetCardFace();
            }
            return face;
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
            return getCardNum() == 2 && countTotalPoint() == BREAK_POINT;
        }
    }
}