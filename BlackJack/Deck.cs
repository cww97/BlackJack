using System;

namespace BlackJack{
    class Deck{ // 牌堆
        private Card[] deckCards;
        private int currentIndex;

        internal Card[] DeckCards{
            get{return deckCards;}
            set{deckCards = value;}
        }

        public int CurrentIndex{
            get{return currentIndex;}
            set{currentIndex = value;}
        }

        public Deck(){
            DeckCards = new Card[52];
            currentIndex = 1;
            //Put cards into array
            for (int i = 1; i <= 52; i++){
                DeckCards[i-1] = new Card(i);
            }
            WashCard(); //  shuffle the cards
        }

        public Card dealCard(){  // 发牌
            if (currentIndex >= 52) return null; // 牌堆里没牌了, null
            currentIndex++;
            return DeckCards[CurrentIndex - 1];
        }

        //  Generate the Random Seed
        public static int RandomNum(){
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        
        public void WashCard(){  // shuffling cards
            for (int i = 0; i < 52; i++){
                Random r0 = new Random(RandomNum());
                int t0 = r0.Next(0, DeckCards.Length);
                Random r1 = new Random(RandomNum());
                int t1 = r1.Next(0, DeckCards.Length);
                // select two random index number, and swap them
                // c# 居然没有 swap 函数，辣鸡
                Card tmp =DeckCards[t0];
                DeckCards[t0] = DeckCards[t1];
                DeckCards[t1] = tmp;
            }
        }
    }
}