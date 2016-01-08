using UnityEngine;
using System.Collections.Generic;

namespace KGCustom.Controller.CharacterController.EnemyController {
    public abstract class KGEnemyController : KGCharacterController
    {
        public SkeletonAnimation m_SkeletonAnim;
        public Transform m_AttackPref;
        [SerializeField]
        protected List<CharacterBehavior.BehaviorCurve> m_behaviors;

        public virtual void hitAttackHandle() {
            
        }

        public virtual void ChangeState() {
        }

        public virtual void DoDefence() {
            m_SkeletonAnim.state.GetCurrent(0).Complete -= StartThinking;
            m_SkeletonAnim.state.GetCurrent(0).Complete += StartThinking;
        }
        public virtual void DoMove() { }
        public virtual void DoAttack(AttackEffect ae) {
            m_SkeletonAnim.AnimationName = ae.name;
            m_SkeletonAnim.state.GetCurrent(0).Complete += StartThinking;
            GameObject go = attackEffectPool.Instantiate();
            go.transform.parent = transform;
            go.transform.position = transform.position;
            AttackEffectController aeCtrl = go.GetComponent<AttackEffectUtility>().m_AttackEffectController;
            aeCtrl.release(this, ae);
            ChangeState();
        }

        protected void StartThinking(Spine.AnimationState state, int index, int loopCount) {
            if(character.curState != null)character.curState.end(this);
            character.curState = null;
        }


    }

}

