using System;

namespace BlackJack{
    class Deck{ // 牌堆
        private Card[] deckCards;
        private int cardCnt;
        private int currentIndex;
        private int GroupNum = 1;

        private Card[] DeckCards{
            get{return deckCards;}
            set{deckCards = value;}
        }

        public int CurrentIndex{
            get{return currentIndex;}
            set{currentIndex = value;}
        }

        public Deck(){
            DeckCards = new Card[52*GroupNum];
            currentIndex = 0;
            cardCnt = 0;
            //Put cards into array
            for (int i = 0; i < 52*GroupNum; i++){
                if (i % 4 == 2) continue;
                DeckCards[cardCnt++] = new Card(i);
            }
            WashCard(); //  shuffle the cards
            Throw2Cards();
            //Console.WriteLine("牌堆牌数：" + cardCnt);
        }


        // requirement change1
        public bool Throw2Cards()
        {
            currentIndex += 2;
            return currentIndex < cardCnt;
        }


        public Card dealCard(){  // 发牌
            if (currentIndex >= cardCnt) return null; // 牌堆里没牌了, null
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
            for (int i = 0; i < 100; i++){
                Random r0 = new Random(RandomNum());
                int t0 = r0.Next(0, cardCnt);
                Random r1 = new Random(RandomNum());
                int t1 = r1.Next(0, cardCnt);
                // select two random index number, and swap them
                // c# 居然没有 swap 函数，辣鸡
                Card tmp =DeckCards[t0];
                DeckCards[t0] = DeckCards[t1];
                DeckCards[t1] = tmp;
            }
        }
    }
}