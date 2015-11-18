using KGCustom.Controller;
using KGCustom.Controller.CharacterController.EnemyController;

namespace KGCustom.Model.Behavior.EnemyBehavior {
    public class General : CharacterBehavior
    {

        public override void execute(KGCharacterController cc)
        {
            if (cc.hitAttacks.Count != 0) {
                ((KGEnemyController)cc).hitAttackHandle();
            }
        }

        public override void begin(KGCharacterController cc)
        {
            KGEnemyController ec = (KGEnemyController)cc;
            ec.m_SkeletonAnim.loop = true;
            ec.m_SkeletonAnim.AnimationName = "idle";
        }

    }

}

