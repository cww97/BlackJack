using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    class GameRoom{
        private Player[] players;
        private Banker banker;
        private Deck deck;

        //Init
        public GameRoom(){
            players = new Player[3];
            for (int i = 0; i < players.Length; i++){
                players[i] = new Player();
                switch (i){
                    case 0 :
                        players[i].Name = "KEN";
                        break;
                    case 1:
                        players[i].Name = "JHON";
                        break;
                    case 2:
                        players[i].Name = "ALICE";
                        break;
                }
            }            
            banker = new Banker();
            banker.Name = "Me";
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
        
        //Send a Card to Banker
        public Card dealOneCardToBanker(){
            Card card = deck.dealCard();
            banker.getCard(card);
            return card;
        }
        
        //Determine Boss if continue Get Card
        public bool isBankerContinue(){
            return banker.IsContinue();
        }
        
        //Get Boss Point
        public int returnDealerTotalCount(){
            return banker.getTotalPoint();
        }    

        //Get Card Number in player
        public int GetPlayerCardNumbers(int No){
            return players[No].returnTotalCardNumInHand();
        }

        //Get Card Number in banker
        public int GetBankerCardNumbers(){
            return banker.returnTotalCardNumInHand();
        }

        //Determine the point of player if out 21 
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