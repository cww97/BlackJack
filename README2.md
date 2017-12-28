# BlackJack Requirement Change

## Changes of Requirements

![reqChange](docs/pics/v2/reqChange.png)

## Solution

### 1. Only 50 cards left(throw 2 cards)

From the first version we can see that, we radomly select two card and then swap them. Repeating this operation many time we can simulate the process of washing cards. In `Deck.cs`, we have a currentIndex which means cards before it has been taken, so if we need to throw 2 cards, we just need to add one function here, and it is pretty easy to realize.

```c#
// requirement change1
public bool Throw2Cards()
{
    currentIndex += 2;
    return currentIndex < cardCnt;
}
```

Call it at the end of `Deck()`, then we realize the operation of throwing 2 cards. get it.

### 2. We can add bet during playing

do some changes on `play()`

I feel the origin 'double'(ask for one more card, make bet double, then over) is pretty stupid. Because we `AddBet()` and `Hit()` can do this. So I replace it with the operation `AddBet()`, which is need in the ppt.

```c#
Console.WriteLine("您有三种选择：1.stand(直接结束), 2.hit(继续要牌), 3.增加赌注.");
Console.WriteLine("输出(1/2/3)进行您的选择：");

-----------------------------

else if (op == 3) { // ---------------增加赌注-------------
    Console.WriteLine("Your Cash: " + g.getPlayerBet(playerIdx) + "/" + g.getPlayerMoney(playerIdx));
    Console.WriteLine("How much bet do you want to add?");
    int addMoney = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("addMoney == " + addMoney);
    if (g.AddBet(playerIdx, addMoney)){
        Console.WriteLine("加注成功，Now: " + g.getPlayerBet(playerIdx) + "/" + g.getPlayerMoney(playerIdx));
    }else{
        Console.WriteLine("余额不足，加注失败");
    }
}
```

### 3. Win/Lose Condition: 22 -> 21

// sweet heart

### 4. Remove all cards whose suit is ♠

We need to do some change in `Deck.cs` to satisfy this requirement. Let us see how we arrange our cards:

>**`Class Card`:** This class has four attributes, `hashNum`, `value`, `flower`, `number`. However only two of them have meaning. The `flower` and `number` are two arraies of const. Because the attribute flower doesn't have any usage in comparing handcard's value between player and banker, we abandon this attribute. As we all know, a pack of cards has 52 cards(drop the Jokers). We number them from 0 to 51, which is called hashNumber(attribute `hashNum`). `hashNum / 4 + 1` is this card's value, and `hashNum % 4` is No of its suits(`flower[hashNum % 4]` is the suit string of this card). So at first our deck are arranged like this: '♥A, ♦A, ♠A, ♣A, ♥2, ♦2, ♠2, ♣2, ♥3, ♦3, ♠3, ♣3 ....', for card 'A', in different conditions it has different values, and to display it we need `A` instead of `1`, we have a special method to handle this. Another const array `number`, this is only to dis three cards `J Q K`, their value(calc by hashNum algorithm) is `11, 12, 12`, respectively. However, in `BlackJack Game`, we make their value to `10, 10, 10`, which is managed in function `countTotalPoint()`.

So, it is pretty easy. We only need to do insert some codes in `Deck()`, delete the cards whose `HashNum % 4 == 2`. Or, We just need ignore the `append()` operation when facing them(there is no `append()`, but you know what I am talking about).

Easy Game.
```c#
for (int i = 0; i < 52; i++){
    if (i % 4 == 2) continue;  // requirement change 4
    DeckCards[cardCnt++] = new Card(i);
}
```

### 5. PointOut: 21 -> 22

This is the same as the requirement change3. We donot need extra change.