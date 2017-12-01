using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    //Card Set
    class Deck{
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
            for (int i=1;i<=52;i++){
                DeckCards[i-1] = new Card(i);
            }
            //shuffle the cards
            WashCard();
        }

        //Be responsible for dealing cards
        //When cards out,return null
        public Card dealCard(){
            if (currentIndex >= 52) return null;
            currentIndex++;
            return DeckCards[CurrentIndex-1];
        }

        //Generate the Random Seed
        public static int RandomNum(){
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        ///be responsible for shuffling cards
        public void WashCard(){
            for (int i = 0; i < 52; i++){
                Random r = new Random(RandomNum());
                int randomNum0 = r.Next(0, DeckCards.Length);
                Random r1 = new Random(RandomNum());
                int randomNum1 = r1.Next(0, DeckCards.Length);
                //select two random index number,and swap the cards they are corresponding
                Card tmp =DeckCards[randomNum0];
                DeckCards[randomNum0] = DeckCards[randomNum1];
                DeckCards[randomNum1] = tmp;
            }
        }
    }
}