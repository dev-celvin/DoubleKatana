using KGCustom.Model.Behavior.EnemyBehavior;
using KGCustom.Model.Character.Enemy;
using UnityEngine;

namespace KGCustom.Controller.CharacterController.EnemyController
{
    public class GunGirlController : KGEnemyController {

        void Awake() {
            character = new GunGirl();
            character.xDirection = Player.instance.xDirection;
            transform.localScale = new Vector3(character.xDirection, 1, 1);
            character.curState = null;
        }
        void Update() {
            if (character.curState != null) character.curState.execute(this);
        }

        public override void hitAttackHandle()
        {
            Model.Attack atk = hitAttacks.Pop();
            character.hp -= atk.m_AttackEffect.getDamageValue();
            transform.localScale = new Vector3(atk.direction, 1, 1);
            character.xDirection = (int)atk.direction;
            GameObject hiteffect = (GameObject)Instantiate(HitEffect, atk.hitPos, HitEffect.transform.rotation);
            hiteffect.GetComponent<HitEffect>().PlayHitEffect(3);
            if (character.hp <= 0)
            {
                m_SkeletonAnim.loop = false;
                m_SkeletonAnim.AnimationName = "die";
                character.curState = null;
                return;
            }
            else {
                m_SkeletonAnim.state.SetAnimation(0, "damage_1", false);
                character.curState = null;
            }
            if (hitAttacks.Count != 0) hitAttackHandle();
        }



    }
}

