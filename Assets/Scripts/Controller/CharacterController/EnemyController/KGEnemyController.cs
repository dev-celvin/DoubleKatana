
using KGCustom.Model.Behavior.EnemyBehavior;
using KGCustom.Model.Character;

namespace KGCustom.Controller.CharacterController.EnemyController {
    public abstract class KGEnemyController : KGCharacterController
    {
        public SkeletonAnimation m_SkeletonAnim;
        public Character m_Character;
        public General g_behavior = new General();
        public Damage d_behavior = new Damage();

        public virtual void hitAttackHandle() {
            
        }

    }

}

