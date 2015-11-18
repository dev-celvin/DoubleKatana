
using System;
using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;

namespace KGCustom.Model.Behavior.EnemyBehavior {
    public class Damage : CharacterBehavior
    {
        public override void execute(KGCharacterController cc)
        {
            KGEnemyController ec = (KGEnemyController)cc;
            if (cc.hitAttacks.Count != 0) {
                ec.hitAttackHandle();
            }
            else {
                if (ec.m_SkeletonAnim.state.GetCurrent(0).time >= ec.m_SkeletonAnim.state.GetCurrent(0).endTime) {
                    ec.m_Character.curState = ec.g_behavior;
                    ec.g_behavior.begin(cc);
                }
            }
        }

    }

}

