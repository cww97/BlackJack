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

        int Init() {
            Console.WriteLine("欢迎来到BlackJack");
            Console.WriteLine("请输入玩家人数：");  // requirement change 6
            int playCnt = Convert.ToInt32(Console.ReadLine());
            Player[] p = new Player[playCnt];
            for (int i = 0; i < playCnt; i++){
                Console.WriteLine("Player" + (i+1) + "  Please enter your name:");
                p[i] = new Player();
                p[i].Name = Console.ReadLine();   
            }
            g.Players = p;
            Console.WriteLine("Welcome, Now we begin our Game.");
            return playCnt;
        }

        private bool Hit(int playerIdx)
        {
            Card c = g.DealOneCardToPlayer(playerIdx);
            Console.WriteLine("得到一张牌: " + c.GetCardFace());
            if (g.IsPointOut(playerIdx)){
                Console.WriteLine("您爆牌了，输了输了");
                return false;
            }
            return true;
        }

        private void AddBet(int playerIdx)
        {
            Console.WriteLine("Your Cash: " + g.GetPlayerBet(playerIdx) + "/" + g.GetPlayerMoney(playerIdx));
            Console.WriteLine("How much bet do you want to add?");
            int addMoney = Convert.ToInt32(Console.ReadLine());
            if (g.AddBet(playerIdx, addMoney)){
                Console.WriteLine("加注成功，Now: " + g.GetPlayerBet(playerIdx) + "/" + g.GetPlayerMoney(playerIdx));
            }else{
                Console.WriteLine("余额不足，加注失败");
            }
        }

        int Play(int playerIdx) {
            // ===========================下注=============================
            int money = g.GetPlayerMoney(playerIdx);
            Console.WriteLine(g.Players[playerIdx].Name + "的余额为： " + money + ", 请下注：");
            int bet = Convert.ToInt32(Console.ReadLine());
            for (;bet > money;){
                Console.WriteLine("没钱别乱下注, again!");
                bet = Console.Read();
            }
            g.PlayerBet(playerIdx, bet);
            // 先给玩家两张牌
            for (int i = 0; i < 2; i++) {
                Card c = g.DealOneCardToPlayer(playerIdx);
                Console.WriteLine("得到一张牌: " + c.GetCardFace());
            }
            // 由玩家决定是否继续
            for (int i = 0; i < 999; i++) {
                Console.WriteLine("您有三种选择：1.stand(直接结束), 2.hit(继续要牌), 3.addBet（增加赌注）.");
                Console.WriteLine("输出(1/2/3)进行您的选择：");
                int op = Convert.ToInt32(Console.ReadLine());
                if (op == 1) break;
                else if (op == 2) { 
                    if (!Hit(playerIdx)) break;
                } else if (op == 3) { 
                    AddBet(playerIdx);
                } else { 
                    Console.WriteLine("输入错误，请重新输入.");
                }
            }
            
            int point = g.PlayerTotalPoint(playerIdx);
            if (!g.IsPointOut(playerIdx)) Console.WriteLine("您的点数为：" + point);
            Console.WriteLine("--------您的表演结束了---------");
            return g.IsPointOut(playerIdx) ? -1 : point;
        }

        private int BankerPlay(){
            // 先给庄家两张牌
            for (int i = 0; i < 2; i++){
                Card c = g.DealOneCardToBanker();
            }
            // 由手牌点数决定是否继续
            while (g.BankerContinue()){
                // --------------hit-----------------
                Card c = g.DealOneCardToBanker();
                if (g.IsBankerOut()){
                    Console.WriteLine("庄家爆牌");
                    break;
                }
            }
            // --------------stand-----------------
            int point = g.DealerTotalCount();
            string face = g.ShowBankerHandCard();
            Console.WriteLine("庄家手牌为："+ face );
            if (!g.IsBankerOut())
            {
                Console.WriteLine("庄家点数为："+ point );
            }
            return point;
        }

        private void PlayersWin(int playCnt){
            Console.WriteLine("玩家胜利");
            int cnt = g.GetWinCnt(playCnt);
            for (int i = 0; i < cnt; i++){
                g.PlayerWin(i, cnt);
                Console.WriteLine(g.Players[i].Name + "胜利，余额为" + g.GetPlayerMoney(i));
            }
            for (int i = cnt; i < playCnt; i++)
            {
                g.PlayerLose(i);
                Console.WriteLine(g.Players[i].Name + "失败，余额为" + g.GetPlayerMoney(i));
            }
        }

        private void BankerWin(int playCnt){
            Console.WriteLine("庄家胜利");
            for (int i = 0; i < playCnt; i++){
                g.PlayerLose(i);
                Console.Write(g.Players[i].Name + "的余额为：" + g.GetPlayerMoney(i));
            }
        }

        public void Main() {
            int playCnt = Init();
            
            Console.WriteLine("开始一轮游戏？(y/n)");
            String op = Console.ReadLine();
            
            for (; op != "n";) {
                int[] playerPoint = new int[11]; // 7 is enough
                for (int i = 0; i < playCnt; i++){
                    playerPoint[i] = Play(i);
                }
                int bankerPoint = BankerPlay();
                int maxPlayerPoint = g.SortPlayers(playCnt);
                if (maxPlayerPoint <= bankerPoint){ // banker win
                    BankerWin(playCnt);
                }else{ // players win
                    PlayersWin(playCnt);
                }
                Console.WriteLine("再来一轮？(y/n)");
                g.Restart();
                op = Console.ReadLine();
            }
            Console.WriteLine("Goodbye.");
            Console.Read();
        }
    }
}
