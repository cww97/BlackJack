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
            Console.WriteLine("来啊，快活啊，反正有，大把时光= =");
            Console.WriteLine("Please enter your name:");
            String UserName = Console.ReadLine();
            Player[] p = new Player[1];
            p[0] = new Player();
            p[0].Name = UserName;
            g.Players = p;
            Console.WriteLine("Welcome, " + g.Players[0].Name);
        }

        int play(int playerIdx) {
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
            for (int i = 0; i < 3; i++) {
                Console.WriteLine("您有三种选择：stand(直接结束), hit(继续要牌), double(加倍结束).");
                Console.WriteLine("输出(s/h/d)进行您的选择：");
                String op = Console.ReadLine();
                if (op == "s"){ // ----------------stand---------------------
                    break;
                } else if (op == "h") { // --------------hit-----------------
                    Card c = g.dealOneCardToPlayer(playerIdx);
                    Console.WriteLine("得到一张牌: " + c.GetCardFace());
                    if (g.IsPointOut(playerIdx)){
                        Console.WriteLine("您爆牌了，输了输了");
                        break;
                    }
                } else if (op == "d") { // ---------------double-------------
                    bool succ = g.playerDouble(playerIdx);
                    if (!succ) {
                        Console.WriteLine("钱不够加倍了，请做其他选择");
                        i--;
                    } else{  //  钱足够加倍
                        Card c = g.dealOneCardToPlayer(playerIdx);
                        Console.WriteLine("得到一张牌: " + c.GetCardFace());
                        if (g.IsPointOut(playerIdx)) Console.WriteLine("您爆牌了，输了输了");
                    }
                    break;
                } else { // error input
                    Console.WriteLine("输入错误，请重新输入.");
                    i--;
                }
            }
            int point = g.returnPlayerTotalPoint(playerIdx);
            if (!g.IsPointOut(playerIdx))
                Console.WriteLine("您的点数为 " + point);
            Console.WriteLine("--------您的表演结束了---------");
            return g.IsPointOut(playerIdx) ? -1 : point;
        }

        int bankerPlay(){

            return 10;
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
                int playerPoint = play(0);
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
