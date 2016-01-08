using UnityEngine;
using KGCustom.Controller;

namespace KGCustom.Model.Behavior.EnemyBehavior.PikeManBehavior {


    public class ATK_1 : CharacterBehavior {
        public ATK_1()
        {
            behaviorType = BehaviorType.Attack;
        }
        public override void execute(KGCharacterController cc)
        {
            base.execute(cc);
        }
    }


    public class ATK_2 : CharacterBehavior {
        public ATK_2() {
            behaviorType = BehaviorType.Attack;
        }
    }

    public class Move : CharacterBehavior {

        public Move() {
            behaviorType = BehaviorType.Move;
            xTransfer = 1;
        }

    }

    public class Defence : CharacterBehavior {
        public Defence() {
            behaviorType = BehaviorType.Defence;
        }
    }
}

