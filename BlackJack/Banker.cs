using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    // 庄家在点数大于17时不会再要牌
    class Banker :Person{
        public bool IsContinue(){
            return (this.GetTotalPoint() < 17&&this.GetTotalPoint() != -1);//???还是不对的样子，有时候庄家手牌明明超过17还是会拿
        }
    }
}
