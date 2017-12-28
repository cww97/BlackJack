using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BlackJack{
    class GameRoom{
        private GameTable g;

        public GameRoom() {
            g = new GameTable();
        }

        void init() {
            Console.WriteLine("欢迎来到BlackJack");
            Console.WriteLine("Please enter your name:");
            String UserName = Console.ReadLine();
            Player[] p = new Player[1];
            p[0] = new Player();
            p[0].Name = UserName;
            g.Players = p;
            Console.WriteLine("Welcome, " + g.Players[0].Name);
        }

        int Play(int playerIdx) {
            // ===========================下注=============================
            int money = g.getPlayerMoney(playerIdx);
            Console.WriteLine("您的余额为： " + money + ", 请下注：");
            int bet = Convert.ToInt32(Console.ReadLine());
            for (;bet > money;){
                Console.WriteLine("没钱别乱下注, again!");
                bet = Console.Read();
            }
            g.playerBet(playerIdx, bet);
            // 先给玩家两张牌
            for (int i = 0; i < 2; i++) {
                Card c = g.dealOneCardToPlayer(playerIdx);
                Console.WriteLine("得到一张牌: " + c.GetCardFace());
            }
            // 由玩家决定是否继续
            for (int i = 0; i < 20; i++) {
                Console.WriteLine("您有三种选择：1.stand(直接结束), 2.hit(继续要牌), 3.增加赌注.");
                Console.WriteLine("输出(1/2/3)进行您的选择：");
                int op = Convert.ToInt32(Console.ReadLine());
                if (op == 1){ // ----------------stand---------------------
                    break;
                } else if (op == 2) { // --------------hit-----------------
                    Card c = g.dealOneCardToPlayer(playerIdx);
                    Console.WriteLine("得到一张牌: " + c.GetCardFace());
                    if (g.IsPointOut(playerIdx)){
                        Console.WriteLine("您爆牌了，输了输了");
                        break;
                    }
                } else if (op == 3) { // ---------------增加赌注-------------
                    Console.WriteLine("Your Cash: " + g.getPlayerBet(playerIdx) + "/" + g.getPlayerMoney(playerIdx));
                    Console.WriteLine("How much bet do you want to add?");
                    int addMoney = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("addMoney == " + addMoney);
                    if (g.AddBet(playerIdx, addMoney)){
                        Console.WriteLine("加注成功，Now: " + g.getPlayerBet(playerIdx) + "/" + g.getPlayerMoney(playerIdx));
                    }
                    else{
                        Console.WriteLine("余额不足，加注失败");
                    }
                } else { // -----------------error input-------------------
                    Console.WriteLine("输入错误，请重新输入.");
                }
            }
            
            int point = g.returnPlayerTotalPoint(playerIdx);
            if (!g.IsPointOut(playerIdx))
                Console.WriteLine("您的点数为 " + point);
            Console.WriteLine("--------您的表演结束了---------");
            return g.IsPointOut(playerIdx) ? -1 : point;
        }

        int bankerPlay(){
            // 先给庄家两张牌
            for (int i = 0; i < 2; i++){
                Card c = g.dealOneCardToBanker();
                Console.WriteLine("得到一张牌 " );
            }
            // 由手牌点数决定是否继续
            while (g.isBankerContinue()){
                // --------------hit-----------------
                Card c = g.dealOneCardToBanker();
                if (g.IsBankerOut()){
                    Console.WriteLine("庄家爆牌了，输了输了");
                    break;
                }
            }
            // --------------stand-----------------
            int point = g.returnDealerTotalCount();
            string face = g.ShowBankerHandCard();
            Console.WriteLine("庄家手牌为："+ face );
            return point;
        }

        void playerWin(int idx){
            Console.WriteLine("赌神你好。。");
            g.playerWin(idx);
            Console.WriteLine("现在余额为" + g.getPlayerMoney(idx));
        }

        void playerLose(int idx){
            Console.WriteLine("发生这种事，我很抱歉。");
            g.playerLose(idx);
            Console.WriteLine("现在余额为" + g.getPlayerMoney(idx));
        }

        public void main() {
            init();
            Console.WriteLine("现在您已坐在 BlackJack 的桌前， 来一盘吗（y/n）");
            String op = Console.ReadLine();
            for (; op != "n";) {
                int playerPoint = Play(0);
                if (g.Players[0].isBlackJack()) {
                    Console.WriteLine("BlackJack!!!");
                    playerWin(0);
                } else if (playerPoint == -1) {
                    playerLose(0);
                } else {
                    int bankerPoint = bankerPlay();
                    if (bankerPoint == -1) playerWin(0);
                    else {
                        if (bankerPoint < playerPoint) playerWin(0);
                        else playerLose(0);
                    }
                }
                Console.WriteLine("再来一轮？");
                g.Restart();
                op = Console.ReadLine();
            }
            Console.WriteLine("Goodbye.");
            Console.Read();
        }
    }
}
