using System;

namespace BlackJack{
    class Card{
        public int value;   // 1..10
        private int hashNum;  // 牌的编号，为什么要用String存呢
        //private readonly String[] flower = { "♥", "♦", "♠", "♣" };
        private readonly String[] flower = { "红桃", "方片", "黑桃", "梅花" };
        private readonly String[] number = { "J", "Q", "K" };

        // 在这个游戏中，牌的花色没用作用，故不做考虑
        // num: 1..52
        public Card(int num){
            this.value = countCardValue(num);
            this.hashNum = num;
        }

        // 从牌的编号得到牌上的真实数字
        private int countCardValue(int num){
            if (num > 40) return 10;  // J Q K 都算 10
            return (num - 1) / 4 + 1; // 111122223333....10101010
        }

        public String GetCardFace(){
            int hash = hashNum - 1;
            String flo = flower[hash % 4];
            String num = (hash < 40) ? (hash/4).ToString() : number[(hash - 40) / 4];
            return flo + " " + num;
        }

        public int GetCardValue(){
            return value;
        }
    }
}
