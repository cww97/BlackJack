using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    // 庄家在点数大于17时不会再要牌
    class Banker :Person{
        public bool IsContinue(){
            return (this.GetTotalPoint() < 17);
        }
    }
}
