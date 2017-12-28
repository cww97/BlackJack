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
        public void GetCard(Card card){
            Hand.addBankedCard(card);
        }

        //Get Point
        public int GetTotalPoint()
        {
            int ret = Hand.countTotalPoint();
            return ret <= 22 ? ret : -1;
        }

        public string GetHandCard(){
            return Hand.showHandCard();
        }
    }
}