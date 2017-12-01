using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    class Card{
        public int value;   //the number of the card,such as "1","10"
        public String fileNum;//the corresponding card file name in the file
        //the suits of card is useless when comparing,only useful in dealing cards to distinguish different cards
        //num in range 1-52
        public Card(int num){
            this.value = countCardValue(num);
            this.fileNum = num.ToString();
        }

        //according to the filename to calculalte the value
        private int countCardValue(int num){
            int value;
            if (num <= 40){
                if (num % 4 == 0) { value = num / 4; }  // 4,12,16...not to add 1
                else { value = (num / 4) + 1; }
            }
            else { value = 10; }  // card's value is 10 when the filename beyond 40
            return value;
        }

        public String GetCardFileName(){
            return fileNum;
        }

        public int GetCardValue(){
            return value;
        }
    }
}
