using KGCustom.Model.Behavior.EnemyBehavior;
using KGCustom.Model.Character.Enemy;
using UnityEngine;

namespace KGCustom.Controller.CharacterController.EnemyController
{
    public class GunGirlController : KGEnemyController {

        void Awake() {
            m_Character = new GunGirl();
            m_Character.xDirection = Player.instance.xDirection;
            transform.localScale = new Vector3(m_Character.xDirection, 1, 1);
            m_Character.curState = g_behavior;
        }
        void Update() {
            if (m_Character.curState != null) m_Character.curState.execute(this);
        }

        public override void hitAttackHandle()
        {
            Model.Attack atk = hitAttacks.Pop();
            m_Character.hp -= atk.m_AttackEffect.getDamageValue();
            transform.localScale = new Vector3(atk.direction, 1, 1);
            m_Character.xDirection = (int)atk.direction;
            GameObject hiteffect = (GameObject)Instantiate(HitEffect, atk.hitPos, HitEffect.transform.rotation);
            hiteffect.GetComponent<HitEffect>().PlayHitEffect(3);
            if (m_Character.hp <= 0)
            {
                m_SkeletonAnim.loop = false;
                m_SkeletonAnim.AnimationName = "die";
                m_Character.curState = null;
                return;
            }
            else {
                m_SkeletonAnim.state.SetAnimation(0, "damage_1", false);
                m_Character.curState = d_behavior;
            }
            if (hitAttacks.Count != 0) hitAttackHandle();
        }



    }
}

