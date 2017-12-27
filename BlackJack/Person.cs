namespace BlackJack{
    class Person{  // Player 和 Banker 的 父类
        private HandCard _hand;
        private string _name;

        protected Person(){
            _hand = new HandCard();
        }

        internal string Name{
            get{return _name;}
            set{_name = value;}
        }

        internal HandCard Hand{
            get{return _hand;}
            set{_hand = value;}
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

        public string getHandCard(){
            return Hand.showHandCard();
        }
    }
}