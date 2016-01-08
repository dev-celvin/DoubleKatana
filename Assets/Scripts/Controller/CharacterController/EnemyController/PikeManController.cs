using KGCustom.Model.Behavior.EnemyBehavior.PikeManBehavior;
using KGCustom.Model.Character;
using KGCustom.Model.Character.Enemy;
using System.Collections.Generic;

using UnityEngine;

namespace KGCustom.Controller.CharacterController.EnemyController
{
    public class PikeManController : KGEnemyController
    { 

        private Dictionary<string, CharacterBehavior> animToState = new Dictionary<string, CharacterBehavior>()
        {
            { "atk_1" ,new ATK_1() },
            { "atk_2", new ATK_2() },
            { "move",  new Move() },
            { "def_damage", new Defence()}
        };

        void Start() {
            if (!initFinished) init();
        }
        void Update()
        {
            if (hitAttacks.Count != 0) {
                hitAttackHandle();
                return;
            }
            if (character.curState != null) character.curState.execute(this);
        }

        protected override void init()
        {
            character = new PikeMan();
            for (int i = 0; i < m_behaviors.Count; i++) {
                if (animToState.ContainsKey(m_behaviors[i].animName))
                    animToState[m_behaviors[i].animName].animCurve = m_behaviors[i].curve;
                else Debug.LogError("PikeManController AnimationCurve Init Error: No " + m_behaviors[i].animName);
            }
            character.xDirection = Global.GlobalValue.XDIRECTION_RIGHT;
            transform.localScale = Vector3.right * transform.localScale.x * -character.xDirection + Vector3.one - Vector3.right;
            character.curState = null;
            attackEffectPool = CharacterContollerUtility.GetAttackEffectPoolByType(character.characterType);
        }

        public override void hitAttackHandle()
        {
            Model.Attack atk = hitAttacks.Pop();
            transform.localScale = new Vector3(atk.direction, 1, 1);
            character.xDirection = (int)atk.direction;
            GameObject hiteffect = (GameObject)Instantiate(HitEffect, atk.hitPos, HitEffect.transform.rotation);
            hiteffect.GetComponent<HitEffect>().PlayHitEffect(4);
            DoDefence();
            if (hitAttacks.Count != 0) hitAttackHandle();
        }

        public override void ChangeState()
        {
            if (character.curState != null) character.curState.end(this);
            if (animToState.ContainsKey(m_SkeletonAnim.AnimationName))
            {
                character.curState = animToState[m_SkeletonAnim.AnimationName];
                character.curState.begin(this);
            }
            else
                character.curState = null;
        }

        public override void DoMove() {
            if (character.curState == animToState["move"]) {
                return;
            }
            m_SkeletonAnim.AnimationName = "move";
            m_SkeletonAnim.state.GetCurrent(0).loop = true;
            ChangeState();
        }

        public override void DoAttack(AttackEffect ae) {
            if (character.curState == animToState[ae.name])
            {
                return;
            }
            base.DoAttack(ae);
        }

        public override void DoDefence()
        {
            if (character.curState == animToState["def_damage"])
            {
                return;
            }
            m_SkeletonAnim.AnimationName = "def_damage";
            m_SkeletonAnim.state.GetCurrent(0).loop = false;
            ChangeState();
            base.DoDefence();
        }
    }
}

