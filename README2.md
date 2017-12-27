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
            return currentIndex < 52;
        }
```

Call it at the end of `Deck()`, then we realize the operation of throwing 2 cards. get it.

### 2. We can add bet during playing

 