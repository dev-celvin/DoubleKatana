using KGCustom.Model.Behavior.EnemyBehavior;
using KGCustom.Model.Character.Enemy;
using UnityEngine;

namespace KGCustom.Controller.CharacterController.EnemyController
{
    public class PikeManController : KGEnemyController
    {

        void Awake()
        {
            m_Character = new PikeMan();
            m_Character.xDirection = Player.instance.xDirection;
            transform.localScale = new Vector3(m_Character.xDirection, 1, 1);
            m_Character.curState = g_behavior;
        }
        void Update()
        {
            if (m_Character.curState != null) m_Character.curState.execute(this);
        }

        public override void hitAttackHandle()
        {
            Model.Attack atk = hitAttacks.Pop();
            transform.localScale = new Vector3(atk.direction, 1, 1);
            m_Character.xDirection = (int)atk.direction;
            GameObject hiteffect = (GameObject)Instantiate(HitEffect, atk.hitPos, HitEffect.transform.rotation);
            hiteffect.GetComponent<HitEffect>().PlayHitEffect(4);
            m_SkeletonAnim.state.SetAnimation(0, "def_damage", false);
            if (hitAttacks.Count != 0) hitAttackHandle();
        }



    }
}

