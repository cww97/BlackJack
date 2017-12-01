using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack{
    //class Banker：BOSS
    //banker should not get another card when banker's totalpoint beyond 17
    class Banker :Person{
        public bool IsContinue(){
            return (this.getTotalPoint() < 17);
        }
    }
}
