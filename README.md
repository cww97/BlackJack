# BlackJack

cww97 和 甜心 的 OOAD Project

working.....

## BackGround

Firstly, to be aware of how BlackJack works, we did some research on [4399](www.4399.com). We saw too many brilliant GUI. Our instructor, however, told us UI is not so significant as our design because this course is called 'OOAD', which emphasizes Analysis & Design. As a result, in our first edition, we made our users to play the game with a console. What's more, many players play one game in one PC is stupid, so, we have only one player in our first edition. 

## Domain Model
![domainModel.PNG](docs/pics/domainModel.PNG)

## Class Model
![classModel.PNG](docs/pics/classModel.PNG)

The following is our introduction for every class:
Class Card：This class has four attributes,hashNum,value,flower,number.Because the attribute flower doesn't have any usage in comparing handcard's value between player and banker,we abandon this attribute.We use ...方式计算牌的值。

Class HandCard:It's inheritancing from Card.It can calculate cards's value which are in hand....

Class Deck:It's describe the card's characteristics.It's mainly to generate a pokercard for players to use.what's more,it can wash card,deal card and so on.

Class Person:It mainly contains players's and bankers's shared attributes and operates for them to inheritance to reduce unnecessary code.

Class Player:Attribute bet is to record bet money.Attribute Money is to record remained money.

Class Banker:It has a method to decide whether banker has to hit or not.

Class GameRoom:It realizes functions that initialize GameTable and Players and begins the game.

Class GameTable:It encapsulates many methods.

Like money and betmoney the two attributes,they can't be a class.Because they doesn't have their own attributes and operates.

= what？？？


## Use Case Model

### 1

![userCase1.PNG](docs/pics/userCase1.PNG)

### 2

![userCase2.PNG](docs/pics/userCase2.PNG)

## System Sequence Diagram

### Player

![sequencePlayer.PNG](docs/pics/sequencePlayer.PNG)

### Banker

![sequenceBanker.PNG](docs/pics/sequenceBanker.PNG)

###Operation Contracts
Player：

Contract CO1:init
操作：init()
交叉引用：
前置条件：
后置条件：

Contract CO2:playerBet
操作：playerBet()
交叉引用：
前置条件：
后置条件：

Contract CO3:dealOneCardToPlayer
操作：dealOneCardToPlayer()
交叉引用：
前置条件：
后置条件：
    
？Contract CO4:直接结束
操作：enterPassengerInfo()
交叉引用：
前置条件：
后置条件：

Contract CO5:playerDouble
操作：playerDouble()
交叉引用：
前置条件：
后置条件：


Banker:

？Contract CO1:判断玩家是否结束
操作：
交叉引用：
前置条件：
后置条件：

Contract CO2:dealOneCareToBanker
操作：dealOneCareToBanker()
交叉引用：
前置条件：
后置条件：

？Contract CO3:直接结束
操作：
交叉引用：
前置条件：
后置条件：

##Summary
This lab is not only exercises our logical thinking ability but also strengthen our abilities of OOAD.